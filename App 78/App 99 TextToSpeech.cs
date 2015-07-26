using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace App_78
{
    public partial class App_99_TextToSpeech : Form
    {
        SpeechSynthesizer voice;
        public App_99_TextToSpeech()
        {
            InitializeComponent();
        }

        private void App_99_TextToSpeech_Load(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cboSelectVoice.SelectedIndex)
                {
                    case 0:
                        voice.SelectVoiceByHints(VoiceGender.NotSet);
                        break;
                    case 1:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                    case 2:
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        break;
                    case 3:
                        voice.SelectVoiceByHints(VoiceGender.Neutral);
                        break;
                    default:
                        break;
                }
                voice.SpeakAsync(txtContent.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Resume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Wav Files|*.wav";
                    sfd.Title = "Save to a Wave File";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        voice.SetOutputToWaveStream(fs);
                        voice.Speak(txtContent.Text);
                        MessageBox.Show("Save Completed ", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
