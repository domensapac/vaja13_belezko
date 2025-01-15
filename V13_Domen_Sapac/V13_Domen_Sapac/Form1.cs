using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace V13_Domen_Sapac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool zaklenjeno = false;
        private bool spremenjeno = false; 
        private bool orodna = true;    
        private bool statusna = true;
        private bool rocnoZapiranje = false; 
        private void toolboxZaklenjeno_Click(object sender, EventArgs e)
        {
            if (zaklenjeno == false)
            {
                zaklenjeno=true;
                toolboxNova.Enabled = false;
                toolboxOdpri.Enabled = false;
                toolboxShrani.Enabled = false;
                toolboxPisava.Enabled = false;
                toolboxBarvaOzadja.Enabled = false;
                toolboxBarvaPisave.Enabled = false;
                toolboxLevaPoravnava.Enabled = false;
                toolboxSredinskaPoravnava.Enabled = false;
                toolboxDesnaPoravnava.Enabled = false;
                toolboxZaklenjeno.Text = "Odkleni orodno vrstico";
                toolboxZaklenjeno.ToolTipText = "Odkleni orodno vrstico";
                toolboxZaklenjeno.Image = (Image)Properties.Resources.ResourceManager.GetObject("unlocked");
                zaklenjeno = true;
            }
            else
            {
                toolboxNova.Enabled = true;
                toolboxOdpri.Enabled = true;
                toolboxShrani.Enabled = true;
                toolboxPisava.Enabled = true;
                toolboxBarvaOzadja.Enabled = true;
                toolboxBarvaPisave.Enabled = true;
                toolboxLevaPoravnava.Enabled = true;
                toolboxSredinskaPoravnava.Enabled = true;
                toolboxDesnaPoravnava.Enabled = true;
                toolboxZaklenjeno.Image= (Image)Properties.Resources.ResourceManager.GetObject("locked");
                toolboxZaklenjeno.Text = "Zakleni orodno vrstico";
                toolboxZaklenjeno.ToolTipText = "Zakleni orodno vrstico";
                zaklenjeno = false; 
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tsmiUndo.Enabled = false;
            tsmiRedo.Enabled = false;
            toolboxUndo.Enabled = false;
            toolboxRedo.Enabled = false;
            tsslStZnakov.Text = "Število znakov: 0";
            tsslDatum.Text = DateTime.Now.ToString("dd. MMMM yyyy");
            tsmiOrodnaVrstica.Image = (Image)Properties.Resources.ResourceManager.GetObject("checkmark");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            tsslStZnakov.Text = "Število znakov: " + richtboxMain.TextLength;
            spremenjeno = true;

            if (richtboxMain.CanUndo)
            {
                tsmiUndo.Enabled = true;
                toolboxUndo.Enabled= true;
            }
            else
            {
                tsmiUndo.Enabled= false;
                toolboxUndo.Enabled= false;
            }

            if (richtboxMain.CanRedo)
            {
                tsmiRedo.Enabled= true;
                toolboxRedo.Enabled= true;
            }
            else
            {
                tsmiRedo.Enabled= false;
                toolboxRedo.Enabled= false;
            }
        }

        private void toolboxLevaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolboxSredinskaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolboxDesnaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void tsmiLevaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tsmiSredinskaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tsmiDesnaPoravnava_Click(object sender, EventArgs e)
        {
            richtboxMain.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolboxBarvaOzadja_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = colorDialogMain.ShowDialog();

            if (rezultat == DialogResult.OK)
            {

                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionBackColor = colorDialogMain.Color;
                }
                else
                {
                    richtboxMain.BackColor = colorDialogMain.Color;
                }
            }
        }

        private void tsmiBarvaOzadja_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = colorDialogMain.ShowDialog();

            if (rezultat == DialogResult.OK)
            {

                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionBackColor = colorDialogMain.Color;
                }
                else
                {
                    richtboxMain.BackColor = colorDialogMain.Color;
                }
            }
        }

        private void toolboxBarvaPisave_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = colorDialogMain.ShowDialog();

            if (rezultat == DialogResult.OK)
            {

                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionColor = colorDialogMain.Color;
                }
                else
                {
                    richtboxMain.ForeColor = colorDialogMain.Color;
                }
            }
        }

        private void tsmiBarvaPisave_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = colorDialogMain.ShowDialog();

            if (rezultat == DialogResult.OK)
            {

                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionColor = colorDialogMain.Color;
                }
                else
                {
                    richtboxMain.ForeColor = colorDialogMain.Color;
                }
            }
        }

        private void toolboxPisava_Click(object sender, EventArgs e)
        {
            DialogResult rezulat = fontDialogMain.ShowDialog();

            if(rezulat == DialogResult.OK)
            {
                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionFont = fontDialogMain.Font;
                }
                else
                {
                    richtboxMain.Font = fontDialogMain.Font;
                }
            }
        }

        private void tsmiPisava_Click(object sender, EventArgs e)
        {
            DialogResult rezulat = fontDialogMain.ShowDialog();

            if (rezulat == DialogResult.OK)
            {
                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionFont = fontDialogMain.Font;
                }
                else
                {
                    richtboxMain.Font = fontDialogMain.Font;
                }
            }
        }


        private void shraniDatoteko()
        {
            /*
            Stream myStream;
            StreamWriter sw;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.FileName = "Beležkov dokument.rtf";
            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                sw = new StreamWriter(myStream);
                sw.WriteLine(richtboxMain.Text);
                sw.Close();
                myStream.Close();
            }
            
            spremenjeno = false; 

            */

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF Files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog.FileName = "Beležkov dokument.rtf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText; 
                    

                    richtboxMain.SaveFile(saveFileDialog.FileName, fileType);
                    MessageBox.Show("Datoteka uspešno shranjena", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Prišlo je do napake pri shranjevanju", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            spremenjeno = false;


        }

        private void odpriDatoteko()
        {
            /*
            openFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richtboxMain.Text = File.ReadAllText(openFileDialog1.FileName);
            }

            richtboxMain.SelectionStart = richtboxMain.Text.Length - 1; // cursor na konec
            richtboxMain.Focus();

            spremenjeno = false;

            */

            OpenFileDialog openFileDialog = new OpenFileDialog();   
            openFileDialog.Filter = "RTF Files (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Naloži datoteko";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;

                    richtboxMain.LoadFile(openFileDialog.FileName, fileType);
                    MessageBox.Show("Datoteka uspešno naložena", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Prišlo je do napake pri nalaganju", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            richtboxMain.SelectionStart = richtboxMain.Text.Length - 1; // cursor na konec
            richtboxMain.Focus();

            spremenjeno = false;

        }


        private void toolboxShrani_Click(object sender, EventArgs e)
        {
            shraniDatoteko();
        }

        private void tsmiShrani_Click(object sender, EventArgs e)
        {
            shraniDatoteko(); 
        }

        private void tsmiIzhod_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Zagotovo želiš zapreti beležko?", "Beležko", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rezultat == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void toolboxNova_Click(object sender, EventArgs e)
        {

            if (spremenjeno == true)
            {
                DialogResult rezultat1 = MessageBox.Show("Ali želiš shraniti spremembe?", "Beležko", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rezultat1 == DialogResult.Yes)
                {
                    shraniDatoteko();
                }
            }
            richtboxMain.Clear();
            richtboxMain.BackColor= Color.White;
            spremenjeno = false;
        }

        private void tsmiNova_Click(object sender, EventArgs e)
        {

            if (spremenjeno == true)
            {
                DialogResult rezultat1 = MessageBox.Show("Ali želiš shraniti spremembe?", "Beležko", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rezultat1 == DialogResult.Yes)
                {
                    shraniDatoteko();
                }
            }
            richtboxMain.Clear();
            spremenjeno=false;
        }

       

        private void toolboxOdpri_Click(object sender, EventArgs e)
        {
            odpriDatoteko();
        }

        private void tsmiOdpri_Click(object sender, EventArgs e)
        {
            odpriDatoteko();
        }

        private void tsmiOrodnaVrstica_Click(object sender, EventArgs e)
        {
            if (orodna == true)
            {
                toolbox1.Visible = false;
                richtboxMain.Location = new Point(richtboxMain.Location.X, 24);
                richtboxMain.Height += toolbox1.Height;
                tsmiOrodnaVrstica.Image = (Image)Properties.Resources.ResourceManager.GetObject("cross");
                orodna = false; 

            }
            else 
            {
                toolbox1.Visible = true;
                richtboxMain.Location = new Point(richtboxMain.Location.X, 69);
                richtboxMain.Height -= toolbox1.Height;
                tsmiOrodnaVrstica.Image = (Image)Properties.Resources.ResourceManager.GetObject("checkmark");
                orodna = true;
            }
        }

        private void tsmiStatusnaVrstica_Click(object sender, EventArgs e)
        {
            if (statusna == true)
            {
                statusStrip1.Visible = false;
                richtboxMain.Height += statusStrip1.Height;
                tsmiStatusnaVrstica.Image = (Image)Properties.Resources.ResourceManager.GetObject("cross");
                statusna = false;

            }
            else
            {
                statusStrip1.Visible = true;
                richtboxMain.Height -= statusStrip1.Height;
                tsmiStatusnaVrstica.Image = (Image)Properties.Resources.ResourceManager.GetObject("checkmark");
                statusna = true;
            }
        }

        private void toolboxUndo_Click(object sender, EventArgs e)
        {
            undoAction(); 
        }

        private void toolboxRedo_Click(object sender, EventArgs e)
        {
            redoAction();
        }

        private void undoAction()
        {
            if (richtboxMain.CanUndo)
            {
                richtboxMain.Undo();
            }
        }

        private void redoAction()
        {
            if (richtboxMain.CanRedo)
            {
                richtboxMain.Redo();
            }
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            undoAction();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            redoAction();
        }

        private void toolboxKopiraj_Click(object sender, EventArgs e)
        {
            richtboxMain.Copy(); 
        }

        private void tsmiKopiraj_Click(object sender, EventArgs e)
        {
            richtboxMain.Copy();
        }

        private void tsmiPrilepi_Click(object sender, EventArgs e)
        {
            richtboxMain.Paste();
        }

        private void toolboxPrilepi_Click(object sender, EventArgs e)
        {
            richtboxMain.Paste();
        }

        private void toolboxIzreži_Click(object sender, EventArgs e)
        {
            richtboxMain.Cut();
        }

        private void tsmiIzreži_Click(object sender, EventArgs e)
        {
            richtboxMain.Cut();
        }


        private void richtboxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "N") //nova
            {
                if (spremenjeno == true)
                {
                    DialogResult rezultat1 = MessageBox.Show("Ali želiš shraniti spremembe?", "Beležko", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (rezultat1 == DialogResult.Yes)
                    {
                        shraniDatoteko();
                    }
                }
                richtboxMain.Clear();
                spremenjeno = false;

            }

            if (e.Control && e.KeyCode.ToString() == "O") //odpri
            {
                odpriDatoteko();
            }

            if (e.Control && e.KeyCode.ToString() == "S") //shrani
            {
                shraniDatoteko();
            }

            if (e.Control && e.KeyCode.ToString() == "Z") //razveljavi
            {
                undoAction();
            }

            if (e.Control && e.KeyCode.ToString() == "Y") //ponovi
            {
                redoAction();
            }

            if (e.KeyCode.ToString() == "F1") //info
            {
                toolstripInformacije.ShowDropDown(); 

            }

            /*
            if (e.Control && e.KeyCode.ToString() == "C") //kopiraj
            {
                richtboxMain.Copy();            }

            if (e.Control && e.KeyCode.ToString() == "X") //izreži
            {
                richtboxMain.Cut();
            }

            if (e.Control && e.KeyCode.ToString() == "V") //prilepi
            {
                richtboxMain.Paste();
            }
            */
        }

        private void tsmiDarkMode_Click(object sender, EventArgs e)
        {
            DarkMode();
        }

        private void tsmiContextMenu_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(toolbox1, new Point(0, toolbox1.Height));
        }

        private void tsmiLightMode_Click(object sender, EventArgs e)
        {
            LightMode();
        }

        private void DarkMode()
        {
            toolbox1.BackColor = Color.Gray;
            statusStrip1.BackColor = Color.Gray;
            menuStrip1.BackColor = Color.Gray;
        }

        private void LightMode()
        {
            toolbox1.BackColor = SystemColors.GradientInactiveCaption;
            statusStrip1.BackColor = SystemColors.Control;
            menuStrip1.BackColor = SystemColors.Control;
        }

        private void tsmiZakleni_Click(object sender, EventArgs e)
        {
            richtboxMain.ReadOnly= true;
        }

        private void tsmiOdkleni_Click(object sender, EventArgs e)
        {
            richtboxMain.ReadOnly = false; 
        }

        private void tsmiUra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trenutni čas: " + DateTime.Now.ToString("HH:mm:ss"));

        }

        private void tsmiOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program Beležko je napisan v C# in deluje kot klasična beležka. Preizkusi ga še sam :)"); 
        }

        private void tsmiPomoc_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "MyAppHelp.cmh"); 
        }


        private void tsmiAvtor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Domen Sapač \n4R1\n24/25\nNRPA\nprof. Dominik Letnar"); 
        }

        private void tsmiSvetliNacin_Click(object sender, EventArgs e)
        {
            LightMode();
        }

        private void tsmiTemniNacin_Click(object sender, EventArgs e)
        {
            DarkMode();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spremenjeno == true)
            {
                DialogResult rezultat1 = MessageBox.Show("Ali želiš shraniti spremembe?", "Beležko", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rezultat1 == DialogResult.Yes)
                {
                    shraniDatoteko();
                }
            }
        }

        private void tsmiMarker_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = colorDialogMain.ShowDialog();

            if (rezultat == DialogResult.OK)
            {
                if ((richtboxMain.SelectedText) != "")
                {
                    richtboxMain.SelectionBackColor = colorDialogMain.Color;
                }
            }
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Napaka pri tiskanju: {ex.Message}");
            }
        }
    }
}
