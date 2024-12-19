namespace PredictDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_select_filepath = new System.Windows.Forms.Button();
            this.textBox_select_filepath = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBox_image_input = new System.Windows.Forms.ListBox();
            this.pictureBox_document_inference_input = new System.Windows.Forms.PictureBox();
            this.button_load_model = new System.Windows.Forms.Button();
            this.textBox_load_model = new System.Windows.Forms.TextBox();
            this.button_start_inference = new System.Windows.Forms.Button();
            this.listBox_image_output = new System.Windows.Forms.ListBox();
            this.pictureBox_document_inference_output = new System.Windows.Forms.PictureBox();
            this.button_open_camera = new System.Windows.Forms.Button();
            this.comboBox_select_camera = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer_camera_input = new AForge.Controls.VideoSourcePlayer();
            this.button_close_camera = new System.Windows.Forms.Button();
            this.button_using_camera = new System.Windows.Forms.Button();
            this.button_document_inference = new System.Windows.Forms.Button();
            this.label_result_title = new System.Windows.Forms.Label();
            this.pictureBox_camera_output = new System.Windows.Forms.PictureBox();
            this.label_ano_ok = new System.Windows.Forms.Label();
            this.label_ano_ng = new System.Windows.Forms.Label();
            this.label_predict_result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_document_inference_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_document_inference_output)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_camera_output)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select_filepath
            // 
            this.button_select_filepath.Location = new System.Drawing.Point(14, 165);
            this.button_select_filepath.Margin = new System.Windows.Forms.Padding(4);
            this.button_select_filepath.Name = "button_select_filepath";
            this.button_select_filepath.Size = new System.Drawing.Size(176, 46);
            this.button_select_filepath.TabIndex = 0;
            this.button_select_filepath.Text = "Select FilePath";
            this.button_select_filepath.UseVisualStyleBackColor = true;
            this.button_select_filepath.Click += new System.EventHandler(this.button_select_filepath_Click);
            // 
            // textBox_select_filepath
            // 
            this.textBox_select_filepath.Location = new System.Drawing.Point(230, 174);
            this.textBox_select_filepath.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_select_filepath.Name = "textBox_select_filepath";
            this.textBox_select_filepath.Size = new System.Drawing.Size(718, 29);
            this.textBox_select_filepath.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listBox_image_input
            // 
            this.listBox_image_input.FormattingEnabled = true;
            this.listBox_image_input.ItemHeight = 18;
            this.listBox_image_input.Location = new System.Drawing.Point(14, 316);
            this.listBox_image_input.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_image_input.Name = "listBox_image_input";
            this.listBox_image_input.Size = new System.Drawing.Size(174, 688);
            this.listBox_image_input.TabIndex = 2;
            this.listBox_image_input.SelectedIndexChanged += new System.EventHandler(this.listBox_image_input_SelectedIndexChanged);
            // 
            // pictureBox_document_inference_input
            // 
            this.pictureBox_document_inference_input.Location = new System.Drawing.Point(230, 316);
            this.pictureBox_document_inference_input.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_document_inference_input.Name = "pictureBox_document_inference_input";
            this.pictureBox_document_inference_input.Size = new System.Drawing.Size(720, 690);
            this.pictureBox_document_inference_input.TabIndex = 3;
            this.pictureBox_document_inference_input.TabStop = false;
            // 
            // button_load_model
            // 
            this.button_load_model.Location = new System.Drawing.Point(14, 250);
            this.button_load_model.Margin = new System.Windows.Forms.Padding(4);
            this.button_load_model.Name = "button_load_model";
            this.button_load_model.Size = new System.Drawing.Size(176, 38);
            this.button_load_model.TabIndex = 4;
            this.button_load_model.Text = "LoadModel";
            this.button_load_model.UseVisualStyleBackColor = true;
            this.button_load_model.Click += new System.EventHandler(this.button_load_model_Click);
            // 
            // textBox_load_model
            // 
            this.textBox_load_model.Location = new System.Drawing.Point(230, 255);
            this.textBox_load_model.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_load_model.Name = "textBox_load_model";
            this.textBox_load_model.Size = new System.Drawing.Size(718, 29);
            this.textBox_load_model.TabIndex = 5;
            // 
            // button_start_inference
            // 
            this.button_start_inference.Location = new System.Drawing.Point(14, 1032);
            this.button_start_inference.Margin = new System.Windows.Forms.Padding(4);
            this.button_start_inference.Name = "button_start_inference";
            this.button_start_inference.Size = new System.Drawing.Size(176, 42);
            this.button_start_inference.TabIndex = 6;
            this.button_start_inference.Text = "Start";
            this.button_start_inference.UseVisualStyleBackColor = true;
            this.button_start_inference.Click += new System.EventHandler(this.button_start_inference_Click);
            // 
            // listBox_image_output
            // 
            this.listBox_image_output.FormattingEnabled = true;
            this.listBox_image_output.ItemHeight = 18;
            this.listBox_image_output.Location = new System.Drawing.Point(14, 316);
            this.listBox_image_output.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_image_output.Name = "listBox_image_output";
            this.listBox_image_output.Size = new System.Drawing.Size(174, 688);
            this.listBox_image_output.TabIndex = 8;
            this.listBox_image_output.SelectedIndexChanged += new System.EventHandler(this.listBox_image_output_SelectedIndexChanged);
            // 
            // pictureBox_document_inference_output
            // 
            this.pictureBox_document_inference_output.Location = new System.Drawing.Point(992, 316);
            this.pictureBox_document_inference_output.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_document_inference_output.Name = "pictureBox_document_inference_output";
            this.pictureBox_document_inference_output.Size = new System.Drawing.Size(720, 690);
            this.pictureBox_document_inference_output.TabIndex = 9;
            this.pictureBox_document_inference_output.TabStop = false;
            // 
            // button_open_camera
            // 
            this.button_open_camera.Location = new System.Drawing.Point(14, 98);
            this.button_open_camera.Margin = new System.Windows.Forms.Padding(4);
            this.button_open_camera.Name = "button_open_camera";
            this.button_open_camera.Size = new System.Drawing.Size(176, 42);
            this.button_open_camera.TabIndex = 10;
            this.button_open_camera.Text = "OpenCamera";
            this.button_open_camera.UseVisualStyleBackColor = true;
            this.button_open_camera.Click += new System.EventHandler(this.button_open_camera_Click);
            // 
            // comboBox_select_camera
            // 
            this.comboBox_select_camera.FormattingEnabled = true;
            this.comboBox_select_camera.Location = new System.Drawing.Point(230, 105);
            this.comboBox_select_camera.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_select_camera.Name = "comboBox_select_camera";
            this.comboBox_select_camera.Size = new System.Drawing.Size(718, 26);
            this.comboBox_select_camera.TabIndex = 11;
            this.comboBox_select_camera.SelectedIndexChanged += new System.EventHandler(this.comboBox_select_camera_SelectedIndexChanged);
            // 
            // videoSourcePlayer_camera_input
            // 
            this.videoSourcePlayer_camera_input.Location = new System.Drawing.Point(230, 330);
            this.videoSourcePlayer_camera_input.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer_camera_input.Name = "videoSourcePlayer_camera_input";
            this.videoSourcePlayer_camera_input.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.videoSourcePlayer_camera_input.Size = new System.Drawing.Size(720, 690);
            this.videoSourcePlayer_camera_input.TabIndex = 12;
            this.videoSourcePlayer_camera_input.Text = "videoSourcePlayer";
            this.videoSourcePlayer_camera_input.VideoSource = null;
            // 
            // button_close_camera
            // 
            this.button_close_camera.Location = new System.Drawing.Point(813, 1034);
            this.button_close_camera.Margin = new System.Windows.Forms.Padding(4);
            this.button_close_camera.Name = "button_close_camera";
            this.button_close_camera.Size = new System.Drawing.Size(136, 40);
            this.button_close_camera.TabIndex = 13;
            this.button_close_camera.Text = "CloseCamera";
            this.button_close_camera.UseVisualStyleBackColor = true;
            this.button_close_camera.Click += new System.EventHandler(this.button_close_camera_Click);
            // 
            // button_using_camera
            // 
            this.button_using_camera.Location = new System.Drawing.Point(20, 20);
            this.button_using_camera.Margin = new System.Windows.Forms.Padding(4);
            this.button_using_camera.Name = "button_using_camera";
            this.button_using_camera.Size = new System.Drawing.Size(170, 50);
            this.button_using_camera.TabIndex = 14;
            this.button_using_camera.Text = "Using Camera";
            this.button_using_camera.UseVisualStyleBackColor = true;
            this.button_using_camera.Click += new System.EventHandler(this.button_using_camera_Click);
            // 
            // button_document_inference
            // 
            this.button_document_inference.Location = new System.Drawing.Point(230, 20);
            this.button_document_inference.Margin = new System.Windows.Forms.Padding(4);
            this.button_document_inference.Name = "button_document_inference";
            this.button_document_inference.Size = new System.Drawing.Size(170, 50);
            this.button_document_inference.TabIndex = 15;
            this.button_document_inference.Text = "Document inference\n";
            this.button_document_inference.UseVisualStyleBackColor = true;
            this.button_document_inference.Click += new System.EventHandler(this.button_document_inference_Click);
            // 
            // label_result_title
            // 
            this.label_result_title.AutoSize = true;
            this.label_result_title.Location = new System.Drawing.Point(1006, 20);
            this.label_result_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_result_title.Name = "label_result_title";
            this.label_result_title.Size = new System.Drawing.Size(57, 18);
            this.label_result_title.TabIndex = 16;
            this.label_result_title.Text = "Result:";
            // 
            // pictureBox_camera_output
            // 
            this.pictureBox_camera_output.Location = new System.Drawing.Point(1024, 330);
            this.pictureBox_camera_output.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_camera_output.Name = "pictureBox_camera_output";
            this.pictureBox_camera_output.Size = new System.Drawing.Size(800, 690);
            this.pictureBox_camera_output.TabIndex = 17;
            this.pictureBox_camera_output.TabStop = false;
            // 
            // label_ano_ok
            // 
            this.label_ano_ok.AutoSize = true;
            this.label_ano_ok.Font = new System.Drawing.Font("微软雅黑", 100F, System.Drawing.FontStyle.Bold);
            this.label_ano_ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label_ano_ok.Location = new System.Drawing.Point(1086, 20);
            this.label_ano_ok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ano_ok.Name = "label_ano_ok";
            this.label_ano_ok.Size = new System.Drawing.Size(413, 264);
            this.label_ano_ok.TabIndex = 18;
            this.label_ano_ok.Text = "OK";
            // 
            // label_ano_ng
            // 
            this.label_ano_ng.AutoSize = true;
            this.label_ano_ng.Font = new System.Drawing.Font("微软雅黑", 100F, System.Drawing.FontStyle.Bold);
            this.label_ano_ng.ForeColor = System.Drawing.Color.Red;
            this.label_ano_ng.Location = new System.Drawing.Point(1148, 21);
            this.label_ano_ng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ano_ng.Name = "label_ano_ng";
            this.label_ano_ng.Size = new System.Drawing.Size(433, 264);
            this.label_ano_ng.TabIndex = 19;
            this.label_ano_ng.Text = "NG";
            this.label_ano_ng.Visible = false;
            // 
            // label_predict_result
            // 
            this.label_predict_result.AutoSize = true;
            this.label_predict_result.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_predict_result.ForeColor = System.Drawing.Color.Black;
            this.label_predict_result.Location = new System.Drawing.Point(1119, 224);
            this.label_predict_result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_predict_result.Name = "label_predict_result";
            this.label_predict_result.Size = new System.Drawing.Size(158, 61);
            this.label_predict_result.TabIndex = 20;
            this.label_predict_result.Text = "result";
            this.label_predict_result.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1866, 1130);
            this.Controls.Add(this.label_predict_result);
            this.Controls.Add(this.label_ano_ng);
            this.Controls.Add(this.label_ano_ok);
            this.Controls.Add(this.pictureBox_camera_output);
            this.Controls.Add(this.label_result_title);
            this.Controls.Add(this.button_document_inference);
            this.Controls.Add(this.button_using_camera);
            this.Controls.Add(this.button_close_camera);
            this.Controls.Add(this.videoSourcePlayer_camera_input);
            this.Controls.Add(this.comboBox_select_camera);
            this.Controls.Add(this.button_open_camera);
            this.Controls.Add(this.pictureBox_document_inference_output);
            this.Controls.Add(this.listBox_image_output);
            this.Controls.Add(this.button_start_inference);
            this.Controls.Add(this.textBox_load_model);
            this.Controls.Add(this.button_load_model);
            this.Controls.Add(this.pictureBox_document_inference_input);
            this.Controls.Add(this.listBox_image_input);
            this.Controls.Add(this.textBox_select_filepath);
            this.Controls.Add(this.button_select_filepath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "AISVision Predict Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_document_inference_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_document_inference_output)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_camera_output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select_filepath;
        private System.Windows.Forms.TextBox textBox_select_filepath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox listBox_image_input;
        private System.Windows.Forms.PictureBox pictureBox_document_inference_input;
        private System.Windows.Forms.Button button_load_model;
        private System.Windows.Forms.TextBox textBox_load_model;
        private System.Windows.Forms.Button button_start_inference;
        private System.Windows.Forms.ListBox listBox_image_output;
        private System.Windows.Forms.PictureBox pictureBox_document_inference_output;
        private System.Windows.Forms.Button button_open_camera;
        private System.Windows.Forms.ComboBox comboBox_select_camera;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer_camera_input;
        private System.Windows.Forms.Button button_close_camera;
        private System.Windows.Forms.Button button_using_camera;
        private System.Windows.Forms.Button button_document_inference;
        private System.Windows.Forms.Label label_result_title;
        private System.Windows.Forms.PictureBox pictureBox_camera_output;
        private System.Windows.Forms.Label label_ano_ok;
        private System.Windows.Forms.Label label_ano_ng;
        private System.Windows.Forms.Label label_predict_result;
    }
}

