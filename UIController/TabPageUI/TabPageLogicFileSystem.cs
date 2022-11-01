
using RCTool_Server.Client.File;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Client.WebCam;
using ServerUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using UIController.ClientUI;

namespace UIController.TabPageUI
{
    public class TabPageLogicFileSystem : TabPageLogic, INotifyPropertyChanged
    {
        public TabPageLogicFileSystem(ClientWindowLogic parent) : base(parent)
        {
        }

        public override void OnExposedToControl(Control ctrl)
        {
            var tp = (CT_FileSystem)ctrl;
            tp.OnListViewItemDoubleClicked = OnListViewItemDoubleClicked;
        }


        #region Event stuff
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        #region Properties
        private string _CurrentPath = @"C:\";
        public string CurrentPath
        {
            get { return _CurrentPath; }
            set
            {
                _CurrentPath = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<FileSystemObject> Entries { get; set; } = new ObservableCollection<FileSystemObject>();
        #endregion




        #region Commands
        private ICommandExt _iCmdNavigate;

        public ICommandExt ICmdNavigate
        {
            get { return _iCmdNavigate ?? (_iCmdNavigate = new ICommandExt(() => Navigate(CurrentPath), () => { return true; })); }
        }
        #endregion



        /// <summary>
        /// Method used to navigate to a specific directory
        /// </summary>
        /// <param name="path">Directory path</param>
        private void Navigate(string path)
        {
            Parent.RcUClient.SendPacket(new OutboundPacket03FileOperation(OutboundPacket03FileOperation.EnumOperation.LIST_DIR_CONTENT, path))
                .ListenForAnswer((packet) =>
                {
                    if(packet is InboundPacket05DirectoryList dirs)
                    {
                        Parent.wpfWindow.Dispatcher.Invoke(() =>
                        {
                            Entries.Clear();
                            dirs.Entries.ForEach((x) => this.Entries.Add(x));
                        });
                        return true;
                    }
                    return false;
                });
        }

        /// <summary>
        /// Method for handling double click event on the filesystem listview
        /// </summary>
        /// <param name="sender">Clicked object</param>
        private void OnListViewItemDoubleClicked(object sender)
        {
            var obj = sender as FileSystemObject;

            if (obj == null) return;

            if (obj.EntryType == FileSystemObject.Type.DIR || obj.EntryType == FileSystemObject.Type.PARENT)
            {
                //navigate to directory
                CurrentPath = obj.FilePath;
                Navigate(CurrentPath);
            }
            else if (obj.EntryType == FileSystemObject.Type.FILE)
            {
                //todo: init file transfer
            }
        }

    }
}
