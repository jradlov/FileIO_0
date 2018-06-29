using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FileIO_0
{
	public partial class MainPage : ContentPage
	{
        string myFileInfo;

		public MainPage()
		{
			InitializeComponent();

            IFolder folder = FileSystem.Current.LocalStorage;

            Console.WriteLine("folder 123 " + folder.Name + "  path: "+ folder.Path);

            BindingContext = this;
            myFileInfo = "folder 123 " + folder.Name + "  path: " + folder.Path;

            myLabel.Text = myFileInfo;


            DependencyServices.Get<Toast>.Show("toast message...");
        }

        public async Task PCLStorageSample()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("answer.txt",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync("42");

            Console.WriteLine("=================== " + folder.Name + "  path:" + folder.Path + "  file:" + file.Name);

        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            await PCLStorageSample();
        }
    }
}
