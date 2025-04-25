using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab_03
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async void DecToBinAndConversely(Object sender, EventArgs e)
        {
            if (txtDec.IsFocused) 
            {
                
                string decText = txtDec.Text;
                if (decText.Length > 0 && decText.Length < 9)
                {
                    int dec = 0;
                    if (!Int32.TryParse(decText, out dec))
                    {
                        await DisplayAlert("Ошибка", "Ваше число не похоже на число...", "ОК");
                        return;
                    }
                    string bin = "";
                    while (dec > 0)
                    {
                        bin = (dec & 1).ToString() + bin;
                        dec = dec >> 1;
                    }
                    txtBin.Text = bin;
                }
            }

            if (txtBin.IsFocused) 
            {
                string binText = txtBin.Text;
                int dec = 0;
                if (binText.Contains("2") || binText.Contains("3") || binText.Contains("4") 
                    || binText.Contains("5") || binText.Contains("6") || binText.Contains("7") 
                    || binText.Contains("8") || binText.Contains("9") || binText.Contains("-"))
                {
                    await DisplayAlert("Ошибка", "Ваше число не двоичное", "ОК");
                    txtBin.Text = "";
                    return;
                }
                for (int i = 0, j = binText.Length - 1; i < binText.Length; i++)
                {
                    if (binText[i] == '1')
                    {
                        dec = (int)(dec + Math.Pow(2, j));
                    }
                    j--;
                }
                txtDec.Text = dec.ToString();
            }
        }
    }
}