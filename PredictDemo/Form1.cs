using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Aisvision;
using AForge.Video.DirectShow;
using static Aisvision.Predictor;

namespace PredictDemo
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        public FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoSource;
        public Bitmap bitImg;
        public int listBoxIndex;
        public DateTime localTime;
        public string folderPath;
        public int b = 0;

        public static Predictor m_AISVPredictor;
        public static Predictor.AisvModelInfo modelInfo;
        public static Predictor.AisvImage AisvImage;
        public static Predictor.AisvCategoryInfo categoryInfo;
        public static Predictor.AisvPredictInfo AisvPredictInfo;
        public static Predictor.AisvImage annotatedImage;
        public List<string> m_ListAllImagePath;
        public List<string> m_ListAllImageName;
        public static string strResultPath;
        private string strModelPath;
        public bool bUseGpu = true;
        public int nGpuIndex = 0;
        private List<string> imagePaths = new List<string>();
        private List<string> afterimagePaths = new List<string>();
        private List<string> m_list_all_predict_result = new List<string>();



        public Form1()
        {
            InitializeComponent();
            m_AISVPredictor = new Predictor();
            listBox_image_output.Visible = true;
            pictureBox_document_inference_input.Visible = true;
            label_ano_ok.Visible = false;
            label_ano_ng.Visible = false;
            button_open_camera.Enabled = false;
            button_select_filepath.Enabled = false;
        }

        // select the camera inference mode
        private void button_using_camera_Click(object sender, EventArgs e)
        {
            button_select_filepath.Enabled = false;
            textBox_select_filepath.Enabled = false;
            pictureBox_camera_output.Visible = true;
            pictureBox_document_inference_input.Visible = false;
            pictureBox_document_inference_output.Visible = false;
            videoSourcePlayer_camera_input.Visible = true;
            button_open_camera.Enabled = true;
            comboBox_select_camera.Enabled = true;
            button_close_camera.Enabled = true;
            listBox_image_input.Visible = false;
            listBox_image_output.Visible = false;
        }

        // select the document inference mode
        private void button_document_inference_Click(object sender, EventArgs e)
        {
            button_open_camera.Enabled = false;
            comboBox_select_camera.Enabled = false;
            button_close_camera.Enabled = false;
            pictureBox_document_inference_output.Visible = true;
            pictureBox_document_inference_input.Visible = true;
            videoSourcePlayer_camera_input.Visible = false;
            pictureBox_camera_output.Visible = false;
            textBox_select_filepath.Enabled = true;
            button_select_filepath.Enabled = true;
            listBox_image_input.Visible = true;
            listBox_image_output.Visible = true;
            listBox_image_output.Enabled = true;
        }

        //Select FilePath
        private void button_select_filepath_Click(object sender, EventArgs e)
        {
            listBox_image_output.Visible = false;
            listBox_image_input.Visible = true;

            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;
                    textBox_select_filepath.Text = selectedPath;
                    load_images(selectedPath);
                }
            }
        }

        private void load_images(string folderPath)
        {
            // Reset ListBox
            listBox_image_input.Items.Clear();

            // Define image extensions
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff" };

            // Get all image files that qualify the rule in folder
            var imageFiles = Directory.GetFiles(folderPath)
                                       .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()));

            // Add image path to ListBox
            foreach (var imageFile in imageFiles)
            {
                listBox_image_input.Items.Add(imageFile);
            }
        }

        private void listBox_image_input_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_image_input.SelectedItem != null)
            {
                string selectedImagePath = listBox_image_input.SelectedItem.ToString();
                Display_input_image(selectedImagePath);
            }
        }

        // View single image inference results
        private void listBox_image_output_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_predict_result.Visible = false;
            label_ano_ng.Visible = false;
            label_ano_ok.Visible = false;
            if (listBox_image_output.SelectedItem != null)
            {
                if (modelInfo.ModelType == ModelType.AnomalyDetection)
                {
                    Console.WriteLine(listBox_image_output.SelectedIndex);
                    if (m_list_all_predict_result[listBox_image_output.SelectedIndex] == "OK")
                    {
                        label_ano_ok.Visible = true;
                    }
                    else if (m_list_all_predict_result[listBox_image_output.SelectedIndex] == "NG")
                    {
                        label_ano_ng.Visible = true;
                    }
                }
                else
                {
                    label_predict_result.Visible = true;
                    label_predict_result.Text = m_list_all_predict_result[listBox_image_output.SelectedIndex];
                }
                string selectedImagePath = listBox_image_output.SelectedItem.ToString();
                Display_output_image(selectedImagePath);
                listBoxIndex = listBox_image_output.SelectedIndex;
                string itemText = listBox_image_input.Items[listBoxIndex].ToString();
                Display_input_image(itemText);

            }
        }

        // Display input image to GUI
        private void Display_input_image(string imagePath)
        {
            try
            {
                pictureBox_document_inference_input.Image?.Dispose(); // Release previously loaded image resources
                pictureBox_document_inference_input.Image = new System.Drawing.Bitmap(imagePath); // Load new image
                pictureBox_document_inference_input.SizeMode = PictureBoxSizeMode.Zoom; // Set display mode
                pictureBox_document_inference_input.Refresh(); // Refresh the PictureBox to display the new image
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load image: {ex.Message}");
            }
        }

        // Display output image to GUI
        private void Display_output_image(string imagePath)
        {
            try
            {
                pictureBox_document_inference_output.Image?.Dispose(); // Release previously loaded image resources
                pictureBox_document_inference_output.Image = new System.Drawing.Bitmap(imagePath); // Load new image
                pictureBox_document_inference_output.SizeMode = PictureBoxSizeMode.Zoom; // Set display mode
                pictureBox_document_inference_output.Refresh(); // Refresh the PictureBox to display the new image
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load image: {ex.Message}");
            }

        }

        // Select and load dedetected camera
        private void button_open_camera_Click(object sender, EventArgs e)
        {
            if (comboBox_select_camera.Items.Count > 0)
            {
                comboBox_select_camera.Items.Clear();
            }

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No camera device detected!");
                return;
            }
            foreach (FilterInfo device in videoDevices)
            {
                comboBox_select_camera.Items.Add(device.Name);
            }
            comboBox_select_camera.SelectedIndex = 0;
        }

        // Select and load AISVision model
        private void button_load_model_Click(object sender, EventArgs e)
        {
            //m_AISVPredictor.SetConfigFile("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v11.8\\bin\\cudart64_110.dll");
            OpenFileDialog openImageFileDialog = new OpenFileDialog();
            openImageFileDialog.Title = "Select File";
            openImageFileDialog.InitialDirectory = ".\\";
            openImageFileDialog.Multiselect = false;
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_ListAllImagePath = openImageFileDialog.FileNames.ToList();
                m_ListAllImageName = openImageFileDialog.SafeFileNames.ToList();
                strModelPath = string.Format("{1}", m_ListAllImagePath.Count, m_ListAllImagePath[0]);
            }
            m_AISVPredictor.LoadModel(strModelPath, bUseGpu, nGpuIndex);
            m_AISVPredictor.GetModelInfo(out modelInfo);
            m_AISVPredictor.GetCategoryInfo(out categoryInfo);
            textBox_load_model.Text = strModelPath;

            
        }


        // Start inference process
        private void button_start_inference_Click(object sender, EventArgs e)
        {
            int a = 0;
            localTime = DateTime.Now;
            folderPath = localTime.ToString("yyyy-MM-dd_HH-mm-ss");
            if (!Directory.Exists(folderPath))
            {
                 Directory.CreateDirectory(folderPath);
            }

            //Folder image inference
            if (button_open_camera.Enabled == false)
            {
                m_list_all_predict_result.Clear();

                if (m_AISVPredictor.CheckDongle())//check Dongle
                {
                    if (m_AISVPredictor.CheckSession())//check Model
                    {
                        //Traverse the image list
                        foreach (var item in listBox_image_input.Items)
                        {
                            a++;
                            Console.WriteLine(item);
                            strResultPath = folderPath+@"\" + a + "1.bmp";
                            string filePath = item.ToString();
                            AisvImage = m_AISVPredictor.ReadImage(filePath);
                            AisvPredictInfo = m_AISVPredictor.Predict(AisvImage); // Predict

                            if (modelInfo.ModelType == ModelType.AnomalyDetection)
                            {
                                m_list_all_predict_result.Add(AisvPredictInfo.anomalydetectionInfo.Name);
                            }
                            else if (modelInfo.ModelType == ModelType.Classification)
                            {
                                m_list_all_predict_result.Add(AisvPredictInfo.classificationInfo.Name);
                            }
                            else if (modelInfo.ModelType == ModelType.ObjectDetection)
                            {
                                string obj_result_label = "";
                                for (int i = 0; i < AisvPredictInfo.objectdetectionInfo.Size; i++)
                                {
                                    obj_result_label += AisvPredictInfo.objectdetectionInfo.ResultList[i].Name;
                                    obj_result_label += ", ";
                                }
                                m_list_all_predict_result.Add(obj_result_label);
                            }
                            else if (modelInfo.ModelType == ModelType.OrientedObjectDetection)
                            {
                                string obj_result_label = "";
                                for (int i = 0; i < AisvPredictInfo.orientedobjectdetectionInfo.Size; i++)
                                {
                                    obj_result_label += AisvPredictInfo.orientedobjectdetectionInfo.ResultList[i].Name;
                                    obj_result_label += ", ";
                                }
                                m_list_all_predict_result.Add(obj_result_label);
                            }
                            else if (modelInfo.ModelType == ModelType.Segmentation)
                            {
                                string obj_result_label = "";
                                for (int i = 0; i < AisvPredictInfo.segmentationInfo.CategorySize; i++)
                                {
                                    obj_result_label += AisvPredictInfo.segmentationInfo.CategoryList[i].Name;
                                    obj_result_label += ", ";
                                }
                                m_list_all_predict_result.Add(obj_result_label);
                            }

                            annotatedImage = m_AISVPredictor.VisualizeResult(AisvImage, AisvPredictInfo);//Obtain results
                            Bitmap bmp = m_AISVPredictor.ConvertImageToBitmap(annotatedImage);//Convert image to bitmap
                            bmp.Save(strResultPath);//save image
                            Thread.Sleep(100);
                        }
                        MessageBox.Show("success", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);//Inference successful
                        listBox_image_output.Items.Clear();
                        DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                        foreach (FileInfo file in dirInfo.GetFiles())
                        {
                            listBox_image_output.Items.Add(folderPath + @"\" + file.Name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("please load model first", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("please check dongle", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

            // Camera inference
            else if (button_select_filepath.Enabled == false)
            {
                //Start a thread to do inference
                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => capture_frames(cancellationTokenSource.Token));
            }
            listBox_image_input.Visible = false;
            listBox_image_output.Visible= true;
        }

        // Start a thread to do Camera inference
        private void capture_frames(CancellationToken cancellationToken)
        {
            localTime = DateTime.Now;
            folderPath = localTime.ToString("yyyy-MM-dd_HH-mm-ss");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                label_ano_ok.Invoke(new Action(() => label_ano_ok.Visible = false));
                label_ano_ng.Invoke(new Action(() => label_ano_ng.Visible = false));
                label_predict_result.Invoke(new Action(() => label_predict_result.Visible = false));

                b++;
                strResultPath = folderPath + @"\" + b + "1.bmp";
                bitImg = videoSourcePlayer_camera_input.GetCurrentVideoFrame();
                AisvImage = m_AISVPredictor.ConvertBitmapToImage(bitImg);
                AisvPredictInfo = m_AISVPredictor.Predict(AisvImage); // Predict
                Console.WriteLine(modelInfo.ModelType);

                if (modelInfo.ModelType == ModelType.AnomalyDetection)
                {
                    Console.WriteLine(AisvPredictInfo.anomalydetectionInfo.Name);
                    if (AisvPredictInfo.anomalydetectionInfo.Name == "OK")
                    {
                        if (label_ano_ok.InvokeRequired)
                        {
                            label_ano_ok.Invoke(new Action(() => label_ano_ok.Visible = true));
                            label_ano_ng.Invoke(new Action(() => label_ano_ng.Visible = false));
                        }
                        Console.WriteLine("OK");
                    }
                    else if (AisvPredictInfo.anomalydetectionInfo.Name == "NG")
                    {
                        if (label_ano_ng.InvokeRequired)
                        {
                            label_ano_ok.Invoke(new Action(() => label_ano_ok.Visible = false));
                            label_ano_ng.Invoke(new Action(() => label_ano_ng.Visible = true));
                        }
                        Console.WriteLine("NG");
                    }
                }
                else if (modelInfo.ModelType == ModelType.Classification)
                {
                    Console.WriteLine(AisvPredictInfo.classificationInfo.Name);
                    if (AisvPredictInfo.classificationInfo.Name != null)
                    {
                        if (label_predict_result.InvokeRequired)
                        {
                            label_predict_result.Invoke(new Action(() => label_predict_result.Visible = true));
                            label_predict_result.Invoke(new Action(() => label_predict_result.Text = "Detected: " + AisvPredictInfo.classificationInfo.Name));
                        }
                        Console.WriteLine(AisvPredictInfo.classificationInfo.Name);
                    }
                }
                else if (modelInfo.ModelType == ModelType.ObjectDetection)
                {
                    Console.WriteLine(AisvPredictInfo.objectdetectionInfo.Size);
                    string obj_result_list = "";
                    for (int i = 0; i < AisvPredictInfo.objectdetectionInfo.Size; i++)
                    {
                        obj_result_list += AisvPredictInfo.objectdetectionInfo.ResultList[i].Name;
                        obj_result_list += ", ";
                    }
                    if (label_predict_result.InvokeRequired)
                    {
                        label_predict_result.Invoke(new Action(() => label_predict_result.Visible = true));
                        label_predict_result.Invoke(new Action(() => label_predict_result.Text = "Detected: " + obj_result_list));
                    }
                }
                else if (modelInfo.ModelType == ModelType.OrientedObjectDetection)
                {
                    Console.WriteLine(AisvPredictInfo.orientedobjectdetectionInfo.Size);
                    string obj_result_list = "";
                    for (int i = 0; i < AisvPredictInfo.orientedobjectdetectionInfo.Size; i++)
                    {
                        obj_result_list += AisvPredictInfo.orientedobjectdetectionInfo.ResultList[i].Name;
                        obj_result_list += ", ";
                    }
                    if (label_predict_result.InvokeRequired)
                    {
                        label_predict_result.Invoke(new Action(() => label_predict_result.Visible = true));
                        label_predict_result.Invoke(new Action(() => label_predict_result.Text = "Detected: " + obj_result_list));
                    }
                }
                else if (modelInfo.ModelType == ModelType.Segmentation)
                {
                    Console.WriteLine(AisvPredictInfo.segmentationInfo.CategorySize);
                    string obj_result_list = "";
                    for (int i = 0; i < AisvPredictInfo.segmentationInfo.CategorySize; i++)
                    {
                        obj_result_list += AisvPredictInfo.segmentationInfo.CategoryList[i].Name;
                        obj_result_list += ", ";
                    }
                    if (label_predict_result.InvokeRequired)
                    {
                        label_predict_result.Invoke(new Action(() => label_predict_result.Visible = true));
                        label_predict_result.Invoke(new Action(() => label_predict_result.Text = "Detected: " + obj_result_list));
                    }
                }
                else
                {
                    Console.WriteLine("return");
                    return;
                }

                annotatedImage = m_AISVPredictor.VisualizeResult(AisvImage, AisvPredictInfo);//Obtain results
                Bitmap bmp = m_AISVPredictor.ConvertImageToBitmap(annotatedImage);//Convert image to bitmap
                bmp.Save(strResultPath);//save image
                pictureBox_camera_output.Image?.Dispose(); // Release previously loaded image resources
                pictureBox_camera_output.Image = new System.Drawing.Bitmap(bmp); // Load new image
                pictureBox_camera_output.SizeMode = PictureBoxSizeMode.Zoom; // Set display mode
                Thread.Sleep(1000);// Photo interval (ms)
            }
        }

        // Select camera index
        private void comboBox_select_camera_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_select_camera.SelectedIndex;
            videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);
            videoSourcePlayer_camera_input.VideoSource = videoSource;
            videoSourcePlayer_camera_input.Start();
        }

        // Click button to Close camera process
        private void button_close_camera_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            shut_down_camera();
            label_ano_ng.Visible = false;
            label_ano_ok.Visible = false;
        }

        // Close camera process
        public void shut_down_camera()
        {
            if (videoSourcePlayer_camera_input.VideoSource != null)
            {
                videoSourcePlayer_camera_input.SignalToStop();
                videoSourcePlayer_camera_input.WaitForStop();
                videoSourcePlayer_camera_input.VideoSource = null;
            }
        }

    }
}
