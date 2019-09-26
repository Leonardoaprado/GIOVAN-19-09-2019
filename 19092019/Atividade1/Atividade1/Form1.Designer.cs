namespace Atividade1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHelloWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHelloWord
            // 
            this.btnHelloWord.Location = new System.Drawing.Point(63, 58);
            this.btnHelloWord.Name = "btnHelloWord";
            this.btnHelloWord.Size = new System.Drawing.Size(186, 108);
            this.btnHelloWord.TabIndex = 0;
            this.btnHelloWord.Text = "Diga OI";
            this.btnHelloWord.UseVisualStyleBackColor = true;
            this.btnHelloWord.Click += new System.EventHandler(this.btnHelloWord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 226);
            this.Controls.Add(this.btnHelloWord);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelloWord;
    }
}

