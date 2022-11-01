/************************************************************************
   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at https://opensource.org/licenses/MS-PL
 ************************************************************************/

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using AvalonDock.Layout;
using System.Diagnostics;
using System.IO;
using AvalonDock.Layout.Serialization;
using AvalonDock;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media.Imaging;

namespace ServerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfWindowClientManager : Window
    {

        public delegate void OnTabPageInserted(LayoutDocument doc, Control tabCtr);
        public event OnTabPageInserted OnTabPageInsertedEvent;

        public WpfWindowClientManager()
        {
            InitializeComponent();
            DataContext = this;
        }


        #region FocusedElement

        /// <summary>
        /// FocusedElement Dependency Property
        /// </summary>
        public static readonly DependencyProperty FocusedElementProperty =
            DependencyProperty.Register("FocusedElement", typeof(string), typeof(WpfWindowClientManager),
                new FrameworkPropertyMetadata((IInputElement)null));

        /// <summary>
        /// Gets or sets the FocusedElement property.  This dependency property 
        /// indicates ....
        /// </summary>
        public string FocusedElement
        {
            get => (string)GetValue(FocusedElementProperty);
            set => SetValue(FocusedElementProperty, value);
        }

        #endregion

        private void OnLayoutRootPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var activeContent = ((LayoutRoot)sender).ActiveContent;
            if (e.PropertyName == "ActiveContent")
            {
                Debug.WriteLine(string.Format("ActiveContent-> {0}", activeContent));
            }
        }

        private void DockManager_DocumentClosing(object sender, DocumentClosingEventArgs e)
        {
        }

        private void EventHandler_TreeView(object sender, MouseButtonEventArgs e)
        {
            if (sender == tviWebcam)
            {
                InsertTab("Kamera", @"Images/camera.png", new CT_WebCam());
            }
            else if (sender == tviFileSystem)
            {
                InsertTab("Pliki", @"Images/folder.png", new CT_FileSystem());
            }
        }

        private void InsertTab(string title, string imgPath, Control contents)
        {
            LayoutDocument doc = new LayoutDocument()
            {
                Title = title,
                IconSource = new BitmapImage(new Uri(imgPath, UriKind.Relative))
            };
            var tabs = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
            doc.Content = contents;
            tabs.Children.Add(doc);
            OnTabPageInsertedEvent?.Invoke(doc, contents);
        }
    }
}
