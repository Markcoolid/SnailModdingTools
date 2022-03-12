using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using SnailModdingTools.lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;

namespace SnailModdingTools.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object selected;
        public object Selected { get => selected; set => this.RaiseAndSetIfChanged(ref selected, value); }

        public MainWindowViewModel()
        {
            OpenFolderCommand = ReactiveCommand.Create<string>(OpenFolder);

            List<SaveFile> files = getExistingSavefiles();
            saves = new ObservableCollection<SaveFile>(files);

            selected = new DescriptionView("Snail Mod Tools", "Welcome to the Will You Snail? mod tools. Please select an item.");
            _selectedItem = new object();

        }

        List<SaveFile> getExistingSavefiles()
        {
            List<SaveFile> saveFiles = new List<SaveFile>();

            string[] fileArray = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
 + "\\Will_You_Snail");

            List<string> files = fileArray.ToList();

            for(int i = 0; i < files.Count; i++)
            {
                files[i] = files[i].Split("\\")[^1];
            }

            if(files.Contains("SaavoGame23-2.sav"))
                saveFiles.Add(new SaveFile(1));
            if (files.Contains("S2-SaavoGame23-2.sav"))
                saveFiles.Add(new SaveFile(2));
            if (files.Contains("S3-SaavoGame23-2.sav"))
                saveFiles.Add(new SaveFile(3));

            return saveFiles;
        }

        public ReactiveCommand<string, Unit> OpenFolderCommand { get; }

        public void OpenFolder(string save)
        {
            var dialogue = new OpenFolderDialog()
            {
                Title = "Select your Will You Snail? folder"
            };

            Window parent = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow
                ?? throw new InvalidOperationException();

            dialogue.ShowAsync(parent);
        }

        private ObservableCollection<SaveFile> saves;
        public ObservableCollection<SaveFile> Saves
        {
            get => saves;
            set
            {
                this.RaiseAndSetIfChanged(ref saves, value);
            }
        }

        private object _selectedItem;
        public object SelectedItem { get { return _selectedItem; } set {
                _selectedItem = value;

                if (value is TreeViewItem item)
                {
                    if (item.Header.ToString() == "Saves")
                    {
                        Selected = new DescriptionView("Saves", "Please select a save");
                    }
                }
                else if(value is SaveFile)
                {
                    Selected = value;
                }
                else
                {
                    Selected = new DescriptionView("Snail Mod Tools", "Welcome to the Will You Snail? mod tools. Please select an item."); ;
                }
            }
        }
    }
}
