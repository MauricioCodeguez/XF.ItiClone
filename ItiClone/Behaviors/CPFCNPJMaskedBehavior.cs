using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ItiClone.Behaviors
{
    public class CPFCNPJMaskedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender is Entry entry && !string.IsNullOrEmpty(entry.Text))
            {
                var text = Regex.Replace(entry.Text, @"\D", "");

                if (text.Length <= 11) // CPF
                {
                    // Coloca um ponto entre o terceiro e o quarto dígitos
                    if (Regex.IsMatch(text, @"^(\d{3})(\d)"))
                        text = Regex.Replace(text, @"^(\d{3})(\d)", "$1.$2");

                    // Coloca um ponto entre o terceiro e o quarto dígitos para o segundo bloco de números  
                    if (Regex.IsMatch(text, @"(\.\d{3})(\d)"))
                        text = Regex.Replace(text, @"(\.\d{3})(\d)", "$1.$2");

                    // Coloca um hífen entre o terceiro e o quarto dígitos para o terceiro bloco de números
                    if (Regex.IsMatch(text, @"(\d{3})(\d{1,2})$"))
                        text = Regex.Replace(text, @"(\d{3})(\d{1,2})$", "$1-$2");
                }
                else // CNPJ
                {
                    // Coloca ponto entre o segundo e o terceiro dígitos
                    if (Regex.IsMatch(text, @"^(\d{2})(\d*)"))
                        text = Regex.Replace(text, @"^(\d{2})(\d*)", "$1.$2");

                    // Coloca ponto entre o quinto e o sexto dígitos
                    if (Regex.IsMatch(text, @"^(\d{2})\.(\d{3})(\d*)"))
                        text = Regex.Replace(text, @"^(\d{2})\.(\d{3})(\d*)", "$1.$2.$3");

                    // Coloca uma barra entre o oitavo e o nono dígitos
                    if (Regex.IsMatch(text, @"^(\d{2})\.(\d{3})\.(\d{3})(\d*)"))
                        text = Regex.Replace(text, @"^(\d{2})\.(\d{3})\.(\d{3})(\d*)", "$1.$2.$3/$4");

                    // Coloca um hífen depois do bloco de quatro dígitos
                    if (Regex.IsMatch(text, @"^(\d{2})\.(\d{3})\.(\d{3})\/(\d{4})(\d{1,2})"))
                        text = Regex.Replace(text, @"^(\d{2})\.(\d{3})\.(\d{3})\/(\d{4})(\d{1,2})", "$1.$2.$3/$4-$5");
                }

                if (entry.Text != text)
                    entry.Text = text;
            }
        }
    }
}