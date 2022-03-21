namespace NotePad
{
    partial class NotePad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotePad));
            this.UpMenu = new System.Windows.Forms.MenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewWindowSimple = new System.Windows.Forms.ToolStripMenuItem();
            this.NewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.EditButton = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeFormatButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FontChangeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.BlackTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeOfSave = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveThirtySeconds = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOneMinute = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFiveMinutes = new System.Windows.Forms.ToolStripMenuItem();
            this.ToHelpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.UpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpMenu
            // 
            this.UpMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.UpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton,
            this.EditButton,
            this.FormatButton,
            this.SettingsButton,
            this.ToHelpButton});
            this.UpMenu.Location = new System.Drawing.Point(0, 0);
            this.UpMenu.Name = "UpMenu";
            this.UpMenu.Size = new System.Drawing.Size(909, 28);
            this.UpMenu.TabIndex = 0;
            this.UpMenu.Text = "Меню";
            // 
            // FileButton
            // 
            this.FileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileButton,
            this.NewWindowSimple,
            this.NewWindow,
            this.OpenButton,
            this.SaveFileButton,
            this.SaveFileAsButton,
            this.SaveAllButton,
            this.ExitButton});
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(59, 24);
            this.FileButton.Text = "Файл";
            // 
            // NewFileButton
            // 
            this.NewFileButton.Image = ((System.Drawing.Image)(resources.GetObject("NewFileButton.Image")));
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewFileButton.Size = new System.Drawing.Size(347, 26);
            this.NewFileButton.Text = "Новый файл";
            this.NewFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
            // 
            // NewWindowSimple
            // 
            this.NewWindowSimple.Image = ((System.Drawing.Image)(resources.GetObject("NewWindowSimple.Image")));
            this.NewWindowSimple.Name = "NewWindowSimple";
            this.NewWindowSimple.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this.NewWindowSimple.Size = new System.Drawing.Size(347, 26);
            this.NewWindowSimple.Text = "Новое окно";
            this.NewWindowSimple.Click += new System.EventHandler(this.NewWindowSimple_Click);
            // 
            // NewWindow
            // 
            this.NewWindow.Image = ((System.Drawing.Image)(resources.GetObject("NewWindow.Image")));
            this.NewWindow.Name = "NewWindow";
            this.NewWindow.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.NewWindow.Size = new System.Drawing.Size(347, 26);
            this.NewWindow.Text = "Создать в новом окне";
            this.NewWindow.Click += new System.EventHandler(this.NewWindow_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenButton.Size = new System.Drawing.Size(347, 26);
            this.OpenButton.Text = "Открыть";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveFileButton.Image")));
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFileButton.Size = new System.Drawing.Size(347, 26);
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // SaveFileAsButton
            // 
            this.SaveFileAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveFileAsButton.Image")));
            this.SaveFileAsButton.Name = "SaveFileAsButton";
            this.SaveFileAsButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveFileAsButton.Size = new System.Drawing.Size(347, 26);
            this.SaveFileAsButton.Text = "Сохранить как...";
            this.SaveFileAsButton.Click += new System.EventHandler(this.SaveFileAsButton_Click);
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAllButton.Image")));
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.SaveAllButton.Size = new System.Drawing.Size(347, 26);
            this.SaveAllButton.Text = "Сохранить всё";
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.ExitButton.Size = new System.Drawing.Size(347, 26);
            this.ExitButton.Text = "Выход";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoButton,
            this.RedoButton,
            this.CutButton,
            this.CopyButton,
            this.PasteButton,
            this.SelectAllButton,
            this.CodeFormatButton});
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(74, 24);
            this.EditButton.Text = "Правка";
            // 
            // UndoButton
            // 
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoButton.Size = new System.Drawing.Size(302, 26);
            this.UndoButton.Text = "Шаг назад";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Image = ((System.Drawing.Image)(resources.GetObject("RedoButton.Image")));
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.RedoButton.Size = new System.Drawing.Size(302, 26);
            this.RedoButton.Text = "Повторить";
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // CutButton
            // 
            this.CutButton.Image = ((System.Drawing.Image)(resources.GetObject("CutButton.Image")));
            this.CutButton.Name = "CutButton";
            this.CutButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutButton.Size = new System.Drawing.Size(302, 26);
            this.CutButton.Text = "Вырезать";
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyButton.Image")));
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyButton.Size = new System.Drawing.Size(302, 26);
            this.CopyButton.Text = "Копировать";
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // PasteButton
            // 
            this.PasteButton.Image = ((System.Drawing.Image)(resources.GetObject("PasteButton.Image")));
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteButton.Size = new System.Drawing.Size(302, 26);
            this.PasteButton.Text = "Вставить";
            this.PasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectAllButton.Image")));
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllButton.Size = new System.Drawing.Size(302, 26);
            this.SelectAllButton.Text = "Выделить всё";
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // CodeFormatButton
            // 
            this.CodeFormatButton.Image = ((System.Drawing.Image)(resources.GetObject("CodeFormatButton.Image")));
            this.CodeFormatButton.Name = "CodeFormatButton";
            this.CodeFormatButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.CodeFormatButton.Size = new System.Drawing.Size(302, 26);
            this.CodeFormatButton.Text = "Форматирование кода";
            this.CodeFormatButton.Click += new System.EventHandler(this.CodeFormatButton_Click);
            // 
            // FormatButton
            // 
            this.FormatButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontChangeButton});
            this.FormatButton.Name = "FormatButton";
            this.FormatButton.Size = new System.Drawing.Size(77, 24);
            this.FormatButton.Text = "Формат";
            // 
            // FontChangeButton
            // 
            this.FontChangeButton.Image = ((System.Drawing.Image)(resources.GetObject("FontChangeButton.Image")));
            this.FontChangeButton.Name = "FontChangeButton";
            this.FontChangeButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FontChangeButton.Size = new System.Drawing.Size(246, 26);
            this.FontChangeButton.Text = "Выбор шрифта";
            this.FontChangeButton.Click += new System.EventHandler(this.FontChangeButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorTheme,
            this.TimeOfSave});
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(98, 24);
            this.SettingsButton.Text = "Настройки";
            // 
            // ColorTheme
            // 
            this.ColorTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WhiteTheme,
            this.BlackTheme});
            this.ColorTheme.Image = ((System.Drawing.Image)(resources.GetObject("ColorTheme.Image")));
            this.ColorTheme.Name = "ColorTheme";
            this.ColorTheme.Size = new System.Drawing.Size(233, 26);
            this.ColorTheme.Text = "Цветовая тема";
            // 
            // WhiteTheme
            // 
            this.WhiteTheme.Image = ((System.Drawing.Image)(resources.GetObject("WhiteTheme.Image")));
            this.WhiteTheme.Name = "WhiteTheme";
            this.WhiteTheme.Size = new System.Drawing.Size(184, 26);
            this.WhiteTheme.Text = "Светлая тема";
            this.WhiteTheme.Click += new System.EventHandler(this.WhiteTheme_Click);
            // 
            // BlackTheme
            // 
            this.BlackTheme.Image = ((System.Drawing.Image)(resources.GetObject("BlackTheme.Image")));
            this.BlackTheme.Name = "BlackTheme";
            this.BlackTheme.Size = new System.Drawing.Size(184, 26);
            this.BlackTheme.Text = "Тёмная тема";
            this.BlackTheme.Click += new System.EventHandler(this.BlackTheme_Click);
            // 
            // TimeOfSave
            // 
            this.TimeOfSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveThirtySeconds,
            this.SaveOneMinute,
            this.SaveFiveMinutes});
            this.TimeOfSave.Image = ((System.Drawing.Image)(resources.GetObject("TimeOfSave.Image")));
            this.TimeOfSave.Name = "TimeOfSave";
            this.TimeOfSave.Size = new System.Drawing.Size(233, 26);
            this.TimeOfSave.Text = "Частота сохранения";
            // 
            // SaveThirtySeconds
            // 
            this.SaveThirtySeconds.Image = ((System.Drawing.Image)(resources.GetObject("SaveThirtySeconds.Image")));
            this.SaveThirtySeconds.Name = "SaveThirtySeconds";
            this.SaveThirtySeconds.Size = new System.Drawing.Size(217, 26);
            this.SaveThirtySeconds.Text = "Каждые 30 секунд";
            this.SaveThirtySeconds.Click += new System.EventHandler(this.SaveThirtySeconds_Click);
            // 
            // SaveOneMinute
            // 
            this.SaveOneMinute.Image = ((System.Drawing.Image)(resources.GetObject("SaveOneMinute.Image")));
            this.SaveOneMinute.Name = "SaveOneMinute";
            this.SaveOneMinute.Size = new System.Drawing.Size(217, 26);
            this.SaveOneMinute.Text = "Каждую минуту";
            this.SaveOneMinute.Click += new System.EventHandler(this.SaveOneMinute_Click);
            // 
            // SaveFiveMinutes
            // 
            this.SaveFiveMinutes.Image = ((System.Drawing.Image)(resources.GetObject("SaveFiveMinutes.Image")));
            this.SaveFiveMinutes.Name = "SaveFiveMinutes";
            this.SaveFiveMinutes.Size = new System.Drawing.Size(217, 26);
            this.SaveFiveMinutes.Text = "Каждые 5 минут";
            this.SaveFiveMinutes.Click += new System.EventHandler(this.SaveFiveMinutes_Click);
            // 
            // ToHelpButton
            // 
            this.ToHelpButton.Name = "ToHelpButton";
            this.ToHelpButton.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ToHelpButton.ShowShortcutKeys = false;
            this.ToHelpButton.Size = new System.Drawing.Size(83, 24);
            this.ToHelpButton.Text = "Помощь";
            this.ToHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Location = new System.Drawing.Point(-5, 31);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(914, 620);
            this.TabControl.TabIndex = 2;
            this.TabControl.DoubleClick += new System.EventHandler(this.TabControl_DoubleClick);
            // 
            // NotePad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 648);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.UpMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(927, 695);
            this.MinimumSize = new System.Drawing.Size(927, 695);
            this.Name = "NotePad";
            this.Text = "NotePad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotePad_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotePad_FormClosed);
            this.UpMenu.ResumeLayout(false);
            this.UpMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip UpMenu;
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem EditButton;
        private System.Windows.Forms.ToolStripMenuItem FormatButton;
        private System.Windows.Forms.ToolStripMenuItem OpenButton;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripMenuItem UndoButton;
        private System.Windows.Forms.ToolStripMenuItem SaveFileButton;
        private System.Windows.Forms.ToolStripMenuItem NewFileButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAsButton;
        private System.Windows.Forms.ToolStripMenuItem SettingsButton;
        private System.Windows.Forms.ToolStripMenuItem ColorTheme;
        private System.Windows.Forms.ToolStripMenuItem FontChangeButton;
        private System.Windows.Forms.ToolStripMenuItem WhiteTheme;
        private System.Windows.Forms.ToolStripMenuItem BlackTheme;
        private System.Windows.Forms.ToolStripMenuItem NewWindow;
        private System.Windows.Forms.ToolStripMenuItem SaveAllButton;
        private System.Windows.Forms.ToolStripMenuItem TimeOfSave;
        private System.Windows.Forms.ToolStripMenuItem SaveOneMinute;
        private System.Windows.Forms.ToolStripMenuItem SaveFiveMinutes;
        private System.Windows.Forms.ToolStripMenuItem SaveThirtySeconds;
        private System.Windows.Forms.ToolStripMenuItem RedoButton;
        private System.Windows.Forms.ToolStripMenuItem CutButton;
        private System.Windows.Forms.ToolStripMenuItem CopyButton;
        private System.Windows.Forms.ToolStripMenuItem PasteButton;
        private System.Windows.Forms.ToolStripMenuItem SelectAllButton;
        private System.Windows.Forms.ToolStripMenuItem ToHelpButton;
        private System.Windows.Forms.ToolStripMenuItem CodeFormatButton;
        private System.Windows.Forms.ToolStripMenuItem NewWindowSimple;
    }
}

