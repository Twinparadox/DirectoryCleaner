﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DirectoryCleaner
{
	public partial class RemoveDuplicateFilesForm : Form
	{
		// FileInfo 클래스와 혼동될 수 있으므로 변수 바꿔야..
		// 인접행렬 구조를 이용해서 자료구조를 개편해볼 것.
		// 확장자별로 리스트 구조 만들고, 확장자별로 1차원 Array로 파일 체크 확인
		// A=B B = C인데 A=C가 아닐 수 없으니까 이거로 충분할 듯.
		// 확장자별로 인접행렬 구조를 만들었다면, 이번에는 리스트뷰그룹별로 인접행렬 구조를 만드는 것이 괜찮을 것 같음.
		private List<FileList> fileInfos = null;

		private List<List<FileList>> fileListTable = null;
		private List<List<List<int>>> indexTable = null;
		private List<ListViewGroup> listGroups = null;

		private bool?[,] checkTable;

		private string extension = Extension.curExtension;
		private string[] extensionList;

		public RemoveDuplicateFilesForm()
		{
			InitializeComponent();

			extensionList = extension.Split(',');

			fileInfos = new List<FileList>();

			fileListTable = new List<List<FileList>>(
				Enum.GetNames(typeof(Extension.ExtensionCode)).Length + 1);
            indexTable = new List<List<List<int>>>(fileListTable.Capacity);
			for (int i = 0; i < fileListTable.Capacity; i++)
			{
				fileListTable.Add(new List<FileList>());
                indexTable.Add(new List<List<int>>());
			}

			listGroups = new List<ListViewGroup>();

			ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
			for (int i = 1; i < fileListTable.Capacity; i++)
			{
				if (fileListTable[i].Count != 0)
				{
					CheckDuplicateFiles(i);
				}
			}
			MakeDuplicateFileList();
		}

		#region 파일 탐색 & 목록 저장

		private void SearchFile(string searchPath)
		{
			if (File.Exists(searchPath))
			{
				try
				{
					FileList element = new FileList(searchPath);
					if (element.ExtensionCode != -1)
					{
						fileInfos.Add(element);
						fileListTable[element.ExtensionCode].Add(element);
					}
				}
				catch (UnauthorizedAccessException e)
				{
					MessageBox.Show(e.Message);
				}
			}
		}

		private void ApplyAllFiles(string directory, Action<string> fileAction)
		{
			foreach (string file in Directory.GetFiles(directory))
			{
				fileAction(file);
			}
			foreach (string subDir in Directory.GetDirectories(directory))
			{
				try
				{
					ApplyAllFiles(subDir, fileAction);
				}
				catch (Exception ex)
				{
				}
			}
		}

		#endregion 파일 탐색 & 목록 저장

		/// <summary>
		/// 단순 해싱 비교 200개 기준 약 0.2초 소요 (LSF가 없는 경우)
		/// LSF가 있는 경우 엄청난 시간 소요됨.
		/// 해시값 비교는 두 파일이 다르다는 걸 입증해줄 수 있을지언정, 같다는 걸 입증할 수는 없음.
		/// 그리하여 ByteToByte로 체크
		/// </summary>

		#region 중복파일 탐색 및 리스트 생성

		public void CheckDuplicateFiles(int code)
		{
			int listSize = fileListTable[code].Count;
			int size = fileInfos.Count;
			bool[] checkFileList = new bool[listSize];
			for (int i = 0; i < listSize; i++)
				checkFileList[i] = false;

			checkTable = new bool?[size, size];

			for (int i = 0; i < listSize; i++)
			{
                int count = 0;
                if (checkFileList[i] == false)
                {
                    List<int> indexList = new List<int>();
                    for (int j = 0; j < listSize; j++)
                    {
                        if (i != j && checkFileList[j] == false && fileListTable[code][i].CompareByteToByte(fileListTable[code][j]))
                        {
                            checkFileList[i] = checkFileList[j] = true;
                            if (count == 0)
                                indexList.Add(i);
                            indexList.Add(j);
                            count++;
                        }
                    }
                    if (indexList.Count > 0)
                    {
                        indexTable[code].Add(indexList);
                    }
                }
			}
		}

		public void MakeDuplicateFileList()
		{
			ListViewDuplicateList.BeginUpdate();
            int tableListSize = indexTable.Count;

            for (int code = 0; code < tableListSize; code++)
            {
                int groupSize = indexTable[code].Count;
                for (int groupIdx = 0; groupIdx < groupSize; groupIdx++)
                {
                    ListViewGroup index = null;
                    int cnt = 0;
                    int size = indexTable[code][groupIdx].Count;
                    for (int i = 0; i < size; i++)
                    {
                        if (cnt == 0)
                        {
                            index = new ListViewGroup(fileListTable[code][indexTable[code][groupIdx][i]].GetFileName());
                            ListViewDuplicateList.Groups.Add(index);
                        }
                        ListViewDuplicateList.Items.Add(
                                new ListViewItem(new string[] {
                                    Extension.GetKorFileType(fileListTable[code][indexTable[code][groupIdx][i]].ExtensionCode),
                                    fileListTable[code][indexTable[code][groupIdx][i]].GetFileName(),
                                    fileListTable[code][indexTable[code][groupIdx][i]].DirectoryPath},
                                index));
                        cnt++;
                    }
                    if (index != null)
                        listGroups.Add(index);
                }
            }
            ListViewDuplicateList.EndUpdate();
		}

		public void RefreshListView()
		{
		}

		#endregion 중복파일 탐색 및 리스트 생성

		#region 버튼 이벤트 처리

		private void ListViewDuplicateList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (ListViewDuplicateList.SelectedItems.Count == 1)
			{
				ListView.SelectedListViewItemCollection items = ListViewDuplicateList.SelectedItems;
				ListViewItem ListViewItem = items[0];
				try
				{
					Process.Start(ListViewItem.SubItems[2].Text);
				}
				catch
				{
					MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
				}
			}
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ButtonDeleteAll_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("파일이 영구히 삭제됩니다.", "경고 - 전체 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					foreach (FileList info in fileInfos)
					{
						info.DeleteFile();
					}
					fileInfos.Clear();
					ListViewDuplicateList.Clear();

					MessageBox.Show("모든 파일이 삭제되었습니다.");
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("오류가 발생했습니다.\n" + ex.Message);
				}
			}
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("파일이 영구히 삭제됩니다.", "경고 - 선택 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					ListView.SelectedListViewItemCollection selectedItem = this.ListViewDuplicateList.SelectedItems;
					int selectedItemSize = selectedItem.Count;
					int fileInfoSize = fileInfos.Count;

					bool[] checkSelected = new bool[selectedItemSize];
					List<FileList> deleteFileList = new List<FileList>();

					for (int i = 0; i < selectedItemSize; i++)
					{
						for (int j = 0; j < fileInfoSize && checkSelected[i] == false; j++)
						{
							if (checkSelected[i] == false && selectedItem[i].SubItems[1].Text.Equals(fileInfos[j].GetFileName()) == true)
							{
								deleteFileList.Add(fileInfos[j]);
								checkSelected[i] = true;
							}
						}
					}

					foreach (FileList info in deleteFileList)
					{
						info.DeleteFile();
					}
					while (selectedItem.Count != 0)
					{
						selectedItem[0].Remove();
					}

					MessageBox.Show("선택한 파일이 삭제되었습니다.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("오류가 발생했습니다.\n" + ex.Message);
				}
			}
		}

		#endregion 버튼 이벤트 처리
	}
}