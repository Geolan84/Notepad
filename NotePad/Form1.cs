using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace NotePad
{
    public partial class NotePad : Form
    {
        //Словарь открытых файлов.
        Dictionary<string, Document> tabs = new Dictionary<string, Document>();
        private Timer myTimer;
        //Нумерация новых файлов.
        private static int number = 1;
        //Информация о статусе (главная или побочная).
        public bool ParentTrue = true;
        public NotePad(bool parent = true)
        {
            try
            {
                InitializeComponent();
                //Таймер автосохранения.
                myTimer = new Timer();
                myTimer.Interval = Properties.Settings.Default.Time;
                myTimer.Enabled = true;
                myTimer.Tick += SaveAllButton_Click;
                //Выбор темы.
                if (Properties.Settings.Default.Theme == "black")
                {
                    BlackTheme_Click(new object(), new EventArgs());
                }
                else WhiteTheme_Click(new object(), new EventArgs());
                ParentTrue = parent;
                OpenOpenedFiles();
            }
            catch (Exception)
            {

            }

        }
        /// <summary>
        /// Метод открытия все вкладок прошлого сеанса.
        /// </summary>
        private void OpenOpenedFiles()
        {
            try
            {
                if (this.ParentTrue)
                {
                    string[] linqs = File.ReadAllLines("..\\..\\..\\Linqs\\OpenedFiles\\files.txt");
                    foreach (string line in linqs)
                    {
                        OpenFileFromLinq(line);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка загрузки сохранённых вкладок!");
            }
        }
        /// <summary>
        /// Метод для открытия вкладки, которая была открыта в прошлый сеанс.
        /// </summary>
        /// <param name="path"></param>
        private void OpenFileFromLinq(string path)
        {
            try
            {
                string name = path.Split('\\')[path.Split('\\').Length - 1];
                if (!tabs.ContainsKey(name))
                {
                    TabPage tabPage = new TabPage(name);
                    Document temoDoc = new Document(path);
                    RichTextBox tempBox = new RichTextBox();
                    tempBox.Size = new Size(TabControl.Size.Width, TabControl.Size.Height - 35);
                    temoDoc.text = tempBox;
                    string extensionOfName = name.Split('.')[1].ToLower();
                    if (extensionOfName != "rtf")
                        temoDoc.text.Text = File.ReadAllText(path);

                    else
                        temoDoc.text.LoadFile(path);
                    tabPage.Controls.Add(temoDoc.text);
                    TabControl.TabPages.Add(tabPage);
                    tabs.Add(name, temoDoc);
                    //Добавляем файл в список открытых.
                    OpenedFiles.AddFile(path);
                    tabs[name].SafeStatus = true;
                    tabs[name].text.TextChanged += ChangeStatus;
                    ContextMenuStrip tempContex = new ContextMenuStrip();
                    ToolStripMenuItem selectAll = new ToolStripMenuItem("Выбрать весь текст");
                    ToolStripMenuItem cutSelected = new ToolStripMenuItem("Вырезать выделенный фрагмент");
                    ToolStripMenuItem copySelected = new ToolStripMenuItem("Копировать выделенный фрагмент");
                    ToolStripMenuItem pasteBuffer = new ToolStripMenuItem("Вставить из буфера обмена");
                    ToolStripMenuItem formatSelected = new ToolStripMenuItem("Задать формат выделенного элемента");
                    tempContex.Items.AddRange(new[] { selectAll, cutSelected, copySelected, pasteBuffer, formatSelected });
                    selectAll.Click += SelectAll_Click;
                    cutSelected.Click += CutSelected_Click;
                    copySelected.Click += CopySelected_Click;
                    pasteBuffer.Click += PasteBuffer_Click;
                    formatSelected.Click += FontChangeButton_Click;
                    tabs[name].text.ContextMenuStrip = tempContex;
                }
                else
                    MessageBox.Show("Этот файл уже открыт или недоступен!");
            }
            catch (Exception)
            {
                //MessageBox.Show("Проблема доступа к сохранённой вкладке!");
            }
        }
        /// <summary>
        /// Метод для сохранения всех открытых файлов.
        /// </summary>
        public void SaveAllFiles()
        {
            try
            {
                if (TabControl.TabPages.Count > 0)
                {
                    int index = TabControl.SelectedIndex;
                    foreach (TabPage item in TabControl.TabPages)
                    {
                        if (tabs[item.Text].Path != "")
                        {
                            TabControl.SelectedTab = item;
                            SaveFileButton_Click(new object(), new EventArgs());
                        }
                    }
                    TabControl.SelectedIndex = index;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Произошла ошибка сохранения!");
            }
        }
        /// <summary>
        /// Обработчик открытия файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string name = ofd.SafeFileName;
                        if (!tabs.ContainsKey(name))
                        {
                            TabPage tabPage = new TabPage(name);
                            Document temoDoc = new Document(ofd.FileName);
                            RichTextBox tempBox = new RichTextBox();
                            tempBox.Size = new Size(TabControl.Size.Width, TabControl.Size.Height - 35);
                            temoDoc.text = tempBox;
                            string extensionOfName = name.Split('.')[1].ToLower();
                            if (extensionOfName != "rtf")
                                temoDoc.text.Text = File.ReadAllText(ofd.FileName);
                            else
                                temoDoc.text.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                            tabPage.Controls.Add(temoDoc.text);
                            TabControl.TabPages.Add(tabPage);
                            TabControl.SelectedIndex = TabControl.TabPages.Count - 1;
                            tabs.Add(name, temoDoc);
                            //Добавляем файл в список открытых.
                            OpenedFiles.AddFile(ofd.FileName);
                            tabs[name].SafeStatus = true;
                            tabs[name].text.TextChanged += ChangeStatus;
                            ContextMenuStrip tempContex = new ContextMenuStrip();
                            ToolStripMenuItem selectAll = new ToolStripMenuItem("Выбрать весь текст");
                            ToolStripMenuItem cutSelected = new ToolStripMenuItem("Вырезать выделенный фрагмент");
                            ToolStripMenuItem copySelected = new ToolStripMenuItem("Копировать выделенный фрагмент");
                            ToolStripMenuItem pasteBuffer = new ToolStripMenuItem("Вставить из буфера обмена");
                            ToolStripMenuItem formatSelected = new ToolStripMenuItem("Задать формат выделенного элемента");
                            tempContex.Items.AddRange(new[] { selectAll, cutSelected, copySelected, pasteBuffer, formatSelected });
                            selectAll.Click += SelectAll_Click;
                            cutSelected.Click += CutSelected_Click;
                            copySelected.Click += CopySelected_Click;
                            pasteBuffer.Click += PasteBuffer_Click;
                            formatSelected.Click += FontChangeButton_Click;
                            tabs[name].text.ContextMenuStrip = tempContex;
                        }
                        else
                            MessageBox.Show("Этот файл уже открыт!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Обработчик изменения документа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeStatus(object sender, EventArgs e)
        {
            try
            {
                tabs[TabControl.SelectedTab.Text].SafeStatus = false;
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки выхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Выход из приложения(я понял это как выход изо всех окон).
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка закрытия!");
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl.TabPages.Count > 0 && tabs[TabControl.SelectedTab.Text].Path != "")
                {
                    string extensionOfName = TabControl.SelectedTab.Text.Split('.')[1].ToLower();
                    string tempName = TabControl.SelectedTab.Text;
                    if (extensionOfName != "rtf")
                    {
                        File.WriteAllText(tabs[tempName].Path, tabs[tempName].text.Text);
                    }
                    else
                    {
                        tabs[tempName].text.SaveFile(tabs[tempName].Path, RichTextBoxStreamType.RichText);

                    }
                    tabs[tempName].SafeStatus = true;
                }
                else if (TabControl.TabPages.Count > 0 && !(tabs[TabControl.SelectedTab.Text].Path != ""))
                {
                    SaveFileAsButton_Click(sender, e);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Не удаётся сохранить файл!");
            }
        }
        /// <summary>
        /// Обработчик для закрытия вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Удаляем файл из списка открытых.
                OpenedFiles.RemoveFile(tabs[TabControl.SelectedTab.Text].Path);
                tabs[TabControl.SelectedTab.Text].text.TextChanged -= ChangeStatus;
                tabs.Remove(TabControl.SelectedTab.Text);
                TabControl.TabPages.Remove(TabControl.SelectedTab);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка закрытия!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку создания нового файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Контекстное меню для файла.
                ContextMenuStrip tempContex = new ContextMenuStrip();
                ToolStripMenuItem selectAll = new ToolStripMenuItem("Выбрать весь текст");
                ToolStripMenuItem cutSelected = new ToolStripMenuItem("Вырезать выделенный фрагмент");
                ToolStripMenuItem copySelected = new ToolStripMenuItem("Копировать выделенный фрагмент");
                ToolStripMenuItem pasteBuffer = new ToolStripMenuItem("Вставить из буфера обмена");
                ToolStripMenuItem formatSelected = new ToolStripMenuItem("Задать формат выделенного элемента");
                tempContex.Items.AddRange(new[] { selectAll, cutSelected, copySelected, pasteBuffer, formatSelected });
                selectAll.Click += SelectAll_Click;
                cutSelected.Click += CutSelected_Click;
                copySelected.Click += CopySelected_Click;
                pasteBuffer.Click += PasteBuffer_Click;
                formatSelected.Click += FontChangeButton_Click;
                //Открытие новой вкладки.
                TabPage tabPage = new TabPage($"Новый файл {number}");
                Document temoDoc = new Document(String.Empty);
                RichTextBox tempBox = new RichTextBox();
                tempBox.Size = new Size(TabControl.Size.Width, TabControl.Size.Height - 35);
                temoDoc.text = tempBox;
                tabPage.Controls.Add(temoDoc.text);
                TabControl.TabPages.Add(tabPage);
                tabs.Add($"Новый файл {number}", temoDoc);
                tabs[$"Новый файл {number}"].text.TextChanged += ChangeStatus;
                tabs[$"Новый файл {number}"].SafeStatus = false;
                tabs[$"Новый файл {number}"].text.ContextMenuStrip = tempContex;
                TabControl.SelectedTab = tabPage;
                SaveFileButton_Click(sender, e);
                number++;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка создания нового файла!");
            }
        }
        /// <summary>
        /// Обработчик кнопки копирования в контекстном меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CopySelected_Click(object sender, EventArgs e)
        {
            try
            {
                tabs[TabControl.SelectedTab.Text].text.Copy();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка копирования!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку смены форматирования фрагмента в контекстном меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormatSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //Вызываем уже существующий обработчик.
                FontChangeButton_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка форматирования!");
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "вставить" в контекстном меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PasteBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                tabs[TabControl.SelectedTab.Text].text.Paste();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка вставки!");
            }
        }
        /// <summary>
        /// Обработчик для выделения фрагмента через контекстное меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                tabs[TabControl.SelectedTab.Text].text.SelectAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка выделения!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "вырезать" в контекстном меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CutSelected_Click(object sender, EventArgs e)
        {
            try
            {
                tabs[TabControl.SelectedTab.Text].text.Cut();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка вырезания!");
            }
        }

        /// <summary>
        /// Метод для "смены" ключа в словаре.
        /// </summary>
        /// <param name="oldKey">Старый ключ.</param>
        /// <param name="newKey">Новый ключ.</param>
        public void ChangeKey(string oldKey, string newKey)
        {
            try
            {
                Document value;
                tabs.Remove(oldKey, out value);
                tabs[newKey] = value;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка перезаписи!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Сохранить как".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileAsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl.TabPages.Count > 0)
                {
                    using (SaveFileDialog ofd = new SaveFileDialog() { ValidateNames = true })
                    {
                        ofd.DefaultExt = "txt";
                        ofd.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt|RichTextBoxes files(*.rtf)|*.rtf";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show(ofd.FileName);
                            string name = ofd.FileName;
                            string extensionOfName = name.Split('.')[1].ToLower();
                            if (extensionOfName != "rtf")
                            {
                                File.WriteAllText(ofd.FileName, tabs[TabControl.SelectedTab.Text].text.Text);
                            }
                            else
                            {
                                tabs[TabControl.SelectedTab.Text].text.SaveFile(ofd.FileName, RichTextBoxStreamType.RichText);
                            }
                            //Обновление статуса.
                            //tabs[TabControl.SelectedTab.Text].SafeStatus = true;
                            if (tabs[TabControl.SelectedTab.Text].Path == "")
                            {
                                string word = ofd.FileName.Split("\\")[ofd.FileName.Split("\\").Length - 1];
                                ChangeKey(TabControl.SelectedTab.Text, word);
                                tabs[word].Path = ofd.FileName;
                                OpenedFiles.AddFile(ofd.FileName);
                                TabControl.SelectedTab.Text = word;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет активного файла. Создайте или откройте новый.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка сохранения!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "отменить шаг".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl.TabPages.Count > 0)
                    tabs[TabControl.SelectedTab.Text].text.Undo();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка отмены!");
            }
        }
        /// <summary>
        /// Обработчик закрытия формы, сохраняющий несохранённые файлы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool tempFlag = true;
            try
            {
                if (TabControl.TabPages.Count > 0)
                {
                    for (int i = 0; i < TabControl.TabPages.Count && tempFlag == true; i++)
                    {
                        TabControl.SelectedTab = TabControl.TabPages[i];
                        if (!tabs[TabControl.SelectedTab.Text].SafeStatus)
                        {
                            int flag = tabs[TabControl.SelectedTab.Text].EndingMessage(TabControl.SelectedTab.Text);
                            switch (flag)
                            {
                                case 0:
                                    //Не сохранять изменения.
                                    tabs[TabControl.TabPages[i].Text].text.TextChanged -= ChangeStatus;
                                    tabs.Remove(TabControl.TabPages[i].Text);
                                    TabControl.TabPages.Remove(TabControl.TabPages[i]);
                                    i--;
                                    break;
                                case 1:
                                    //Сохранить изменения.
                                    SaveFileButton_Click(sender, e);
                                    tabs[TabControl.TabPages[i].Text].text.TextChanged -= ChangeStatus;
                                    tabs.Remove(TabControl.TabPages[i].Text);
                                    TabControl.TabPages.Remove(TabControl.TabPages[i]);
                                    i--;
                                    break;
                                case -1:
                                    //Отменить закрытие.
                                    e.Cancel = true;
                                    tempFlag = false;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка сохранения!");
            }


        }
        /// <summary>
        /// Класс, каждый объект которого ставится в соответствие с вкладкой.
        /// </summary>
        public class Document
        {
            //Путь открытого/созданного файла.
            string path = String.Empty;
            //Поле статуса сохранности файла.
            public bool SafeStatus { get; set; }
            public string Path
            {
                get
                {
                    return path;
                }
                set
                {
                    path = value;
                }
            }
            //Textbox конкретного файла.
            public RichTextBox text;
            /// <summary>
            /// Метод опроса пользователя о судьбе файла при закрытии.
            /// </summary>
            /// <param name="name">Имя файла.</param>
            /// <returns></returns>
            public int EndingMessage(string name)
            {
                try
                {
                    //Уведомление о закрытии с 3 кнопками.
                    DialogResult result = MessageBox.Show($"Вы собираетесь закрыть программу. {Environment.NewLine}Сохранить изменения в файле?", $"{name}",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button3,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                        return 1;
                    if (result == DialogResult.Cancel)
                        return -1;
                    if (result == DialogResult.No)
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Произошла ошибка обработки файла!");
                }
                return 0;
            }
            public Document(string path)
            {
                Path = path;
            }

        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Выбор шрифта".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl.TabPages.Count > 0)
                {
                    //Вызов и применение настроек FontDialog.
                    FontDialog font = new FontDialog();
                    if (font.ShowDialog() == DialogResult.OK)
                    {
                        tabs[TabControl.SelectedTab.Text].text.SelectionFont = font.Font;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка смены настроек форматирования!");
            }
        }
        /// <summary>
        /// Обработчик выбора светлой темы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhiteTheme_Click(object sender, EventArgs e)
        {
            try
            {
                //Изменение цвета элементов меню.
                this.BackColor = this.UpMenu.BackColor = this.NewFileButton.BackColor = this.OpenButton.BackColor = Color.White;
                this.UpMenu.ForeColor = this.NewFileButton.ForeColor = this.OpenButton.ForeColor = Color.Black;
                this.SaveFileAsButton.BackColor = this.SaveFileButton.BackColor = this.ExitButton.BackColor = Color.White;
                this.SaveFileAsButton.ForeColor = this.SaveFileButton.ForeColor = this.ExitButton.ForeColor = Color.Black;
                this.EditButton.BackColor = this.UndoButton.BackColor = this.RedoButton.BackColor = Color.White;
                this.EditButton.ForeColor = this.UndoButton.ForeColor = this.RedoButton.ForeColor = Color.Black;
                this.FormatButton.BackColor = this.SettingsButton.BackColor = ColorTheme.BackColor = Color.White;
                this.FormatButton.ForeColor = this.SettingsButton.ForeColor = ColorTheme.ForeColor = Color.Black;
                this.FontChangeButton.BackColor = this.WhiteTheme.BackColor = this.BlackTheme.BackColor = Color.White;
                this.FontChangeButton.ForeColor = this.WhiteTheme.ForeColor = this.BlackTheme.ForeColor = Color.Black;
                this.SaveAllButton.BackColor = this.NewWindow.BackColor = this.TimeOfSave.BackColor = Color.White;
                this.SaveAllButton.ForeColor = this.NewWindow.ForeColor = this.TimeOfSave.ForeColor = Color.Black;
                this.SaveFiveMinutes.BackColor = this.SaveThirtySeconds.BackColor = this.SaveOneMinute.BackColor = Color.White;
                this.SaveFiveMinutes.ForeColor = this.SaveThirtySeconds.ForeColor = this.SaveOneMinute.ForeColor = Color.Black;
                this.CutButton.BackColor = this.PasteButton.BackColor = this.SelectAllButton.BackColor = Color.White;
                this.CutButton.ForeColor = this.PasteButton.ForeColor = this.SelectAllButton.ForeColor = Color.Black;
                this.CodeFormatButton.BackColor = this.CopyButton.BackColor = this.NewWindowSimple.BackColor = Color.White;
                this.CodeFormatButton.ForeColor = this.CopyButton.ForeColor = this.NewWindowSimple.ForeColor = Color.Black;
                //Обновление настроек выбора темы.
                Properties.Settings.Default.Theme = "white";
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка смены цветовой темы!");
            }
        }
        /// <summary>
        /// Обработчик выбора тёмной темы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlackTheme_Click(object sender, EventArgs e)
        {
            try
            {
                //Смена цветов элементов меню.
                this.BackColor = Color.Black;
                this.UpMenu.BackColor = this.NewFileButton.BackColor = this.OpenButton.BackColor = Color.Black;
                this.UpMenu.ForeColor = this.NewFileButton.ForeColor = this.OpenButton.ForeColor = Color.White;
                this.SaveFileAsButton.BackColor = this.SaveFileButton.BackColor = this.ExitButton.BackColor = Color.Black;
                this.SaveFileAsButton.ForeColor = this.SaveFileButton.ForeColor = this.ExitButton.ForeColor = Color.White;
                this.EditButton.BackColor = this.UndoButton.BackColor = this.RedoButton.BackColor = Color.Black;
                this.EditButton.ForeColor = this.UndoButton.ForeColor = this.RedoButton.ForeColor = Color.White;
                this.FormatButton.BackColor = this.SettingsButton.BackColor = ColorTheme.BackColor = Color.Black;
                this.FormatButton.ForeColor = this.SettingsButton.ForeColor = ColorTheme.ForeColor = Color.White;
                this.FontChangeButton.BackColor = this.WhiteTheme.BackColor = this.BlackTheme.BackColor = Color.Black;
                this.FontChangeButton.ForeColor = this.WhiteTheme.ForeColor = this.BlackTheme.ForeColor = Color.White;
                this.SaveAllButton.BackColor = this.NewWindow.BackColor = this.TimeOfSave.BackColor = Color.Black;
                this.SaveAllButton.ForeColor = this.NewWindow.ForeColor = this.TimeOfSave.ForeColor = Color.White;
                this.SaveFiveMinutes.BackColor = this.SaveThirtySeconds.BackColor = this.SaveOneMinute.BackColor = Color.Black;
                this.SaveFiveMinutes.ForeColor = this.SaveThirtySeconds.ForeColor = this.SaveOneMinute.ForeColor = Color.White;
                this.CutButton.BackColor = this.PasteButton.BackColor = this.SelectAllButton.BackColor = this.CopyButton.BackColor = Color.Black;
                this.CutButton.ForeColor = this.PasteButton.ForeColor = this.SelectAllButton.ForeColor = this.CopyButton.ForeColor = Color.White;
                this.CodeFormatButton.BackColor = this.NewWindowSimple.BackColor = Color.Black;
                this.CodeFormatButton.ForeColor = this.NewWindowSimple.ForeColor = Color.White;
                //Обновление настроек.
                Properties.Settings.Default.Theme = "black";
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка смены цветовой темы!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Создать в новом окне".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWindow_Click(object sender, EventArgs e)
        {
            try
            {
                //Сохдание нового объекта с пометкой, что он не первый.
                NotePad newForm = new NotePad(false);
                newForm.Show();
                //Вызов создания нового файла в новом окне.
                newForm.NewFileButton_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка создания нового окна!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Сохранить всё".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAllFiles();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка сохранения всех файлов!");
            }
        }
        /// <summary>
        /// Обработчик выбора 30-секундного автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveOneMinute_Click(object sender, EventArgs e)
        {
            try
            {
                //Сохранение и применение настроек автосохранения.
                Properties.Settings.Default.Time = 60000;
                Properties.Settings.Default.Save();
                myTimer.Interval = Properties.Settings.Default.Time;
                myTimer.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка выбора частоты автосохранения!");
            }
        }
        /// <summary>
        /// Обработчик выбора автосохранения раз в 5 минут.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFiveMinutes_Click(object sender, EventArgs e)
        {
            try
            {
                //Сохранение и применение настроек автосохранения.
                Properties.Settings.Default.Time = 300000;
                Properties.Settings.Default.Save();
                myTimer.Interval = Properties.Settings.Default.Time;
                myTimer.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка выбора частоты автосохранения!");
            }
        }
        /// <summary>
        /// Обработчик выбора 30-секундного автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveThirtySeconds_Click(object sender, EventArgs e)
        {
            try
            {
                //Сохранение и применение настроек автосохранения.
                Properties.Settings.Default.Time = 30000;
                Properties.Settings.Default.Save();
                myTimer.Interval = Properties.Settings.Default.Time;
                myTimer.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка выбора частоты автосохранения!");
            }
        }
        /// <summary>
        /// Обработчик закрытой формы для записи путей последних файлов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotePad_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //Запись путей всех файлов, которые были открыты перед закрытием.
                File.WriteAllText("..\\..\\..\\Linqs\\OpenedFiles\\files.txt", String.Join($"{Environment.NewLine}", OpenedFiles.linqs));
            }
            catch (Exception)
            {
                MessageBox.Show("Проблемы с доступом к данным о вкладках!");
            }
        }
        /// <summary>
        /// Обработчки нажатия на кнопку отмены в меню "Правка".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedoButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверка на существование вкладок.
                if (TabControl.TabPages.Count > 0)
                    tabs[TabControl.SelectedTab.Text].text.Redo();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка отмены действия!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку вырезания в меню "Правка".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверка существования активной вкладки.
                if (TabControl.SelectedIndex != -1)
                    CutSelected_Click(new object(), new EventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка вырезания!");
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку копирования текста в меню "Правка".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверка на сущестование активной вкладки.
                if (TabControl.SelectedIndex != -1)
                    CopySelected_Click(new object(), new EventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка копирования!");
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки для вставки текста в меню "Правка".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверка на существование активной вкладки.
                if (TabControl.SelectedIndex != -1)
                    PasteBuffer_Click(new object(), new EventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка вставки!");
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки для выделенеия текста в меню "Правка".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Делаем проверку на существование открытой вкладки.
                if (TabControl.SelectedIndex != -1)
                    SelectAll_Click(new object(), new EventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка выделения!");
            }
        }
        /// <summary>
        /// Инструкция к программе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Инструкция по эксплуатации (можно вызвать через F1).{Environment.NewLine}{Environment.NewLine}" +
                $"1) Для закрытия открытой вкладки нажмите на неё 2 раза!{Environment.NewLine}{Environment.NewLine}" +
                $"2) Чтобы открыть/создать/сохранить файл воспользуйтесь меню \"Файл\".{Environment.NewLine}{Environment.NewLine}" +
                $"3) Для действий над текстом - меню \"Правка\" и \"Формат\". Для корректной работы установите курсор внутри текста.{Environment.NewLine}{Environment.NewLine}" +
                $"4) В настройках у вас есть возможность выбрать цветовую тему и периодичность автосохранения открытых файлов " +
                $"(раз в 30 секунд, раз в минуту и раз в 5 минут).{Environment.NewLine}{Environment.NewLine}" +
                $"5) При сохранении файлов обязательно прописывайте расширение, иначе будет выбран формат *.txt {Environment.NewLine}(Также можно выбрать расширение в списке внизу) {Environment.NewLine}{Environment.NewLine}" +
                $"6) Для вызова контекстного меню в тексте, кликните правой кнопкой мыши.", "Справка");
        }
        /// <summary>
        /// Метод для форматирвоания кода и подстановки через буфер.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeFormatButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl.SelectedIndex != -1)
                {
                    RichTextBox textTemp = new RichTextBox();
                    foreach (string line in tabs[TabControl.SelectedTab.Text].text.Lines)
                    {
                        textTemp.AppendText($"{Environment.NewLine}" + line.Trim());
                    }
                    RichTextBox textTemp2 = new RichTextBox();
                    int indentCount = 0;
                    bool shouldIndent = false;
                    bool flag = false;
                    foreach (string line in textTemp.Lines)
                    {
                        flag = line.Contains("{") && line.Contains("}");
                        if (!flag)
                        {
                            if (shouldIndent)
                                indentCount++;
                            if (line.Contains("}"))
                                indentCount--;
                        }
                        if (indentCount == 0)
                        {
                            textTemp2.AppendText($"{Environment.NewLine}" + line);
                            shouldIndent = line.Contains("{");
                            continue;
                        }
                        string tab = string.Empty;
                        for (int i = 0; i < indentCount; i++)
                        {
                            tab += "    ";
                        }
                        textTemp2.AppendText($"{Environment.NewLine}" + tab + line);
                        if (!flag)
                            shouldIndent = line.Contains("{");
                    }
                    //Подставляем в буфер обмена.
                    if (textTemp2.Text.Trim() != "")
                    {
                        Clipboard.SetText(textTemp2.Text.Trim());
                        SelectAllButton_Click(new object(), new EventArgs());
                        PasteBuffer_Click(new object(), new EventArgs());
                        Clipboard.SetText(" ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка форматирования!" + ex.StackTrace);
            }
        }
        /// <summary>
        /// Открытие нового окна без файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWindowSimple_Click(object sender, EventArgs e)
        {
            try
            {
                //Сохдание нового объекта с пометкой, что он не первый.
                NotePad newForm = new NotePad(false);
                newForm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка создания нового окна!");
            }
        }
    }
    /// <summary>
    /// Статический класс для запоминания открытых вкладок.
    /// </summary>
    public static class OpenedFiles
    {
        //Лист путей к открытым файлам.
        public static List<string> linqs = new List<string>();
        /// <summary>
        /// Метод для добавления пути.
        /// </summary>
        /// <param name="path">путь к файлу.</param>
        public static void AddFile(string path)
        {
            if (!linqs.Contains(path))
                linqs.Add(path);
        }
        /// <summary>
        /// Метод для исключения пути.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        public static void RemoveFile(string path)
        {
            if (linqs.Contains(path))
                linqs.Remove(path);
        }
    }
}

