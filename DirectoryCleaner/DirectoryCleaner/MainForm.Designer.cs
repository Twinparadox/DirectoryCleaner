﻿namespace DirectoryCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TextPath = new System.Windows.Forms.TextBox();
            this.ButtonFinder = new System.Windows.Forms.Button();
            this.ButtonList = new System.Windows.Forms.Button();
            this.ButtonSetting = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonDuplicate = new System.Windows.Forms.Button();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextPath
            // 
            this.TextPath.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextPath.Location = new System.Drawing.Point(12, 27);
            this.TextPath.Name = "TextPath";
            this.TextPath.ReadOnly = true;
            this.TextPath.Size = new System.Drawing.Size(562, 26);
            this.TextPath.TabIndex = 0;
            this.TextPath.TabStop = false;
            this.TextPath.Text = "Directory Path";
            this.TextPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextPath_MouseClick);
            // 
            // ButtonFinder
            // 
            this.ButtonFinder.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonFinder.Location = new System.Drawing.Point(580, 25);
            this.ButtonFinder.Name = "ButtonFinder";
            this.ButtonFinder.Size = new System.Drawing.Size(112, 28);
            this.ButtonFinder.TabIndex = 1;
            this.ButtonFinder.Text = "Find";
            this.ButtonFinder.UseVisualStyleBackColor = true;
            this.ButtonFinder.Click += new System.EventHandler(this.ButtonFinder_Click);
            // 
            // ButtonList
            // 
            this.ButtonList.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonList.Location = new System.Drawing.Point(553, 82);
            this.ButtonList.Name = "ButtonList";
            this.ButtonList.Size = new System.Drawing.Size(139, 47);
            this.ButtonList.TabIndex = 2;
            this.ButtonList.Text = "목록보기";
            this.ButtonList.UseVisualStyleBackColor = true;
            this.ButtonList.Click += new System.EventHandler(this.ButtonList_Click);
            // 
            // ButtonSetting
            // 
            this.ButtonSetting.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonSetting.Location = new System.Drawing.Point(553, 202);
            this.ButtonSetting.Name = "ButtonSetting";
            this.ButtonSetting.Size = new System.Drawing.Size(139, 47);
            this.ButtonSetting.TabIndex = 3;
            this.ButtonSetting.Text = "설정";
            this.ButtonSetting.UseVisualStyleBackColor = true;
            this.ButtonSetting.Click += new System.EventHandler(this.ButtonSetting_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonExit.Location = new System.Drawing.Point(553, 262);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(139, 47);
            this.ButtonExit.TabIndex = 4;
            this.ButtonExit.Text = "닫기";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonDuplicate
            // 
            this.ButtonDuplicate.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonDuplicate.Location = new System.Drawing.Point(553, 142);
            this.ButtonDuplicate.Name = "ButtonDuplicate";
            this.ButtonDuplicate.Size = new System.Drawing.Size(139, 47);
            this.ButtonDuplicate.TabIndex = 5;
            this.ButtonDuplicate.Text = "파일조회";
            this.ButtonDuplicate.UseVisualStyleBackColor = true;
            this.ButtonDuplicate.Click += new System.EventHandler(this.ButtonDuplicate_Click);
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelCopyright.Location = new System.Drawing.Point(10, 358);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(393, 12);
            this.LabelCopyright.TabIndex = 6;
            this.LabelCopyright.Text = "Copyrightⓒ. 2017-2018. Twinparadox. All Rights Reserved.";
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonHelp.Location = new System.Drawing.Point(12, 262);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonHelp.Size = new System.Drawing.Size(139, 47);
            this.ButtonHelp.TabIndex = 7;
            this.ButtonHelp.Text = "도움말";
            this.ButtonHelp.UseVisualStyleBackColor = true;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 379);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.ButtonDuplicate);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSetting);
            this.Controls.Add(this.ButtonList);
            this.Controls.Add(this.ButtonFinder);
            this.Controls.Add(this.TextPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectoryCleaner v1.2.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextPath;
        private System.Windows.Forms.Button ButtonFinder;
        private System.Windows.Forms.Button ButtonList;
        private System.Windows.Forms.Button ButtonSetting;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonDuplicate;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.Button ButtonHelp;
    }
}

