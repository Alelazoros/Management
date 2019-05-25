using System.IO;

namespace Management
{
    public class Settings
    {
        public string dbpath { get; set; }

        public Settings() { }

        public bool Set_DB_Path( )
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            fbd.SelectedPath = Directory.GetCurrentDirectory();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dbpath = fbd.SelectedPath + "\\db.sqlite";
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
