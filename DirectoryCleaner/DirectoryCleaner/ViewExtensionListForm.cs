﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryCleaner
{
    public partial class ViewExtensionListForm : Form
    {
        private String[] strAudio = new String[] { "오디오", Extension.audioExtension + Extension.userAudioExtension };
        private String[] strCompac = new String[] { "압축", Extension.compacExtension + Extension.userCompacExtension };
        private String[] strDevelope = new String[] { "개발", Extension.developeExtension + Extension.userDevelopeExtension };
        private String[] strDisc = new String[] { "디스크", Extension.discExtension + Extension.userDiscExtension };
        private String[] strDocument = new String[] { "문서", Extension.docExtension + Extension.userDocExtension };
        private String[] strEtc = new String[] { "사용자정의", Extension.userEtcExtension };
        private String[] strImage = new String[] { "이미지", Extension.imgExtension + Extension.userImgExtension };
        private String[] strTxt = new String[] { "텍스트", Extension.txtExtension + Extension.userTxtExtension };
        private String[] strVideo = new String[] { "비디오", Extension.videoExtension + Extension.userVideoExtension };

        private string[] ComboBoxData = { "오디오", "압축", "개발", "디스크", "문서", "이미지", "텍스트", "비디오", "사용자정의" };
        private bool[] checkdata = new bool[9];

        public ViewExtensionListForm()
        {
            InitializeComponent();
        }

        private void ViewExtensionList_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.TopMost = true;
            this.Focus();

            this.ListViewExtension.BeginUpdate();
            this.ListViewExtension.Items.Add(new ListViewItem(strAudio));
            this.ListViewExtension.Items.Add(new ListViewItem(strCompac));
            this.ListViewExtension.Items.Add(new ListViewItem(strDevelope));
            this.ListViewExtension.Items.Add(new ListViewItem(strDisc));
            this.ListViewExtension.Items.Add(new ListViewItem(strDocument));
            this.ListViewExtension.Items.Add(new ListViewItem(strImage));
            this.ListViewExtension.Items.Add(new ListViewItem(strTxt));
            this.ListViewExtension.Items.Add(new ListViewItem(strVideo));
            this.ListViewExtension.Items.Add(new ListViewItem(strEtc));
            this.ListViewExtension.EndUpdate();

            this.ComboBoxList.BeginUpdate();
            this.ComboBoxList.Items.AddRange(ComboBoxData);
            this.ComboBoxList.EndUpdate();

            CheckBoxAudio.Checked = checkdata[0] = Properties.Settings.Default.isAudio;
            CheckBoxCompact.Checked = checkdata[1] = Properties.Settings.Default.isCompac;
            CheckBoxDevelope.Checked = checkdata[2] = Properties.Settings.Default.isDevelope;
            CheckBoxDisc.Checked = checkdata[3] = Properties.Settings.Default.isDisc;
            CheckBoxDocument.Checked = checkdata[4] = Properties.Settings.Default.isDoc;
            CheckBoxImage.Checked = checkdata[5] = Properties.Settings.Default.isImg;
            CheckBoxTxt.Checked = checkdata[6] = Properties.Settings.Default.isTxt;
            CheckBoxVideo.Checked = checkdata[7] = Properties.Settings.Default.isVideo;
            CheckBoxEtc.Checked = checkdata[8] = Properties.Settings.Default.isEtc;
        }

        // 확장자 추가
        private void ButtonAddExtension_Click(object sender, EventArgs e)
        {
            if (txtExtension.Text == "" || ComboBoxList.SelectedItem == null)
            {
                MessageBox.Show("확장자 종류와 이름을 입력해주세요.");
            }
            else
            {
                if (ComboBoxList.SelectedItem.ToString().Equals("오디오"))
                {
                    Extension.userAudioExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("압축"))
                {
                    Extension.userCompacExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("개발"))
                {
                    Extension.userDevelopeExtension += txtExtension.Text + ",";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("디스크"))
                {
                    Extension.userDiscExtension += txtExtension.Text + ",";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("문서"))
                {
                    Extension.userDocExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("이미지"))
                {
                    Extension.userImgExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("텍스트"))
                {
                    Extension.userTxtExtension += txtExtension.Text + ",";
                }
                else if (ComboBoxList.SelectedItem.ToString().Equals("비디오"))
                {
                    Extension.userVideoExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
                else
                {
                    Extension.userEtcExtension += txtExtension.Text + ",";
                    //Extension.curExtension += txtExtension.Text + ";";
                }
            }
            UpdateListViewExtension();
        }

        // 리스트뷰 업데이트
        private void UpdateListViewExtension()
        {
            this.ListViewExtension.BeginUpdate();
            this.ListViewExtension.Items[0].SubItems[1].Text = Extension.audioExtension + Extension.userAudioExtension;
            this.ListViewExtension.Items[1].SubItems[1].Text = Extension.compacExtension + Extension.userCompacExtension;
            this.ListViewExtension.Items[2].SubItems[1].Text = Extension.developeExtension + Extension.userDevelopeExtension;
            this.ListViewExtension.Items[3].SubItems[1].Text = Extension.discExtension + Extension.userDiscExtension;
            this.ListViewExtension.Items[4].SubItems[1].Text = Extension.docExtension + Extension.userDocExtension;
            this.ListViewExtension.Items[5].SubItems[1].Text = Extension.imgExtension + Extension.userImgExtension;
            this.ListViewExtension.Items[6].SubItems[1].Text = Extension.txtExtension + Extension.userTxtExtension;
            this.ListViewExtension.Items[7].SubItems[1].Text = Extension.videoExtension + Extension.userVideoExtension;
            this.ListViewExtension.Items[8].SubItems[1].Text = Extension.userEtcExtension;
            this.ListViewExtension.EndUpdate();

            txtExtension.Text = "";
            ComboBoxList.Text = "확장자 종류 선택";
        }

        // 폼 업데이트
        private void UpdateForm()
        {
            UpdateListViewExtension();
            txtExtension.Text = "";
            ComboBoxList.Text = "확장자 종류 선택";
        }

        #region 체크박스 이벤트 메서드
        private void CheckBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[0] = Properties.Settings.Default.isAudio = CheckBoxAudio.Checked;
        }

        private void CheckBoxCompact_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[1] = Properties.Settings.Default.isCompac = CheckBoxCompact.Checked;
        }

        private void CheckBoxDevelope_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[2] = Properties.Settings.Default.isDevelope = CheckBoxDevelope.Checked;
        }

        private void CheckBoxDisc_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[3] = Properties.Settings.Default.isDisc = CheckBoxDisc.Checked;
        }

        private void CheckBoxDocument_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[4] = Properties.Settings.Default.isDoc = CheckBoxDocument.Checked;
        }

        private void CheckBoxImage_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[5] = Properties.Settings.Default.isImg = CheckBoxImage.Checked;
        }

        private void CheckBoxTxt_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[6] = Properties.Settings.Default.isTxt = CheckBoxTxt.Checked;
        }

        private void CheckBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[7] = Properties.Settings.Default.isVideo = CheckBoxVideo.Checked;
        }

        private void CheckBoxEtc_CheckedChanged(object sender, EventArgs e)
        {
            checkdata[8] = Properties.Settings.Default.isEtc = CheckBoxEtc.Checked;
        }
        #endregion

        // 폼 종료 시
        private void ViewExtensionList_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangeSetting();
        }

        // 확인 버튼
        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            ChangeSetting();
            this.Close();
        }

        // 세팅 변화
        private void ChangeSetting()
        {
            Extension.curExtension = "";
            if (Properties.Settings.Default.isAudio)
            {
                Extension.curExtension = Extension.audioExtension + Extension.userAudioExtension;
            }
            if (Properties.Settings.Default.isCompac)
            {
                Extension.curExtension += Extension.compacExtension + Extension.userCompacExtension;
            }
            if (Properties.Settings.Default.isDisc)
            {
                Extension.curExtension += Extension.discExtension + Extension.userDiscExtension;
            }
            if (Properties.Settings.Default.isDoc)
            {
                Extension.curExtension += Extension.docExtension + Extension.userDocExtension;
            }
            if (Properties.Settings.Default.isEtc)
            {
                Extension.curExtension += Extension.userEtcExtension;
            }
            if (Properties.Settings.Default.isImg)
            {
                Extension.curExtension += Extension.imgExtension + Extension.userImgExtension;
            }
            if (Properties.Settings.Default.isTxt)
            {
                Extension.curExtension += Extension.txtExtension + Extension.userTxtExtension;
            }
            if (Properties.Settings.Default.isVideo)
            {
                Extension.curExtension += Extension.videoExtension + Extension.userVideoExtension;
            }
            SettingForm.pTxtExtension.Text = Extension.curExtension;
        }
    }
}
