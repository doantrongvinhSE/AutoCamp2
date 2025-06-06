namespace AutoCamp
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            panel5 = new Panel();
            adsAccountTable = new DataGridView();
            cbxTable = new DataGridViewCheckBoxColumn();
            stt = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            nameTkqc = new DataGridViewTextBoxColumn();
            bill = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            role = new DataGridViewTextBoxColumn();
            country = new DataGridViewTextBoxColumn();
            currency = new DataGridViewTextBoxColumn();
            timezone = new DataGridViewTextBoxColumn();
            isPrepay = new DataGridViewTextBoxColumn();
            dateCreated = new DataGridViewTextBoxColumn();
            budget = new DataGridViewTextBoxColumn();
            threshold = new DataGridViewTextBoxColumn();
            credit = new DataGridViewTextBoxColumn();
            limit = new DataGridViewTextBoxColumn();
            pagePost = new DataGridViewTextBoxColumn();
            startTime = new DataGridViewTextBoxColumn();
            endTime = new DataGridViewTextBoxColumn();
            pixel = new DataGridViewTextBoxColumn();
            process = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnLoadAgain = new ToolStripMenuItem();
            btnOnOffCamp = new ToolStripMenuItem();
            btnClearOptions = new ToolStripMenuItem();
            contextMenuStrip3 = new ContextMenuStrip(components);
            btnClearSelectedData = new ToolStripMenuItem();
            btnClearAllData = new ToolStripMenuItem();
            btnSelectedOptions = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            btnSelectedBlackData = new ToolStripMenuItem();
            btnSelectedAllData = new ToolStripMenuItem();
            btnUnselectedBlackData = new ToolStripMenuItem();
            btnUnselectedAll = new ToolStripMenuItem();
            btnCheckCredit = new ToolStripMenuItem();
            btnAddCredit = new ToolStripMenuItem();
            panel4 = new Panel();
            panel7 = new Panel();
            btnClearAllDraft = new Button();
            button19 = new Button();
            button18 = new Button();
            button17 = new Button();
            button16 = new Button();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            btnCampPe = new Button();
            btnCampBpOptions = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            btnCheckTKLT = new Button();
            btnDeleteCredit = new Button();
            btnAddCreditOptions = new Button();
            btnCheckXMSDT = new Button();
            txtSearchIdTkqc = new TextBox();
            panel3 = new Panel();
            cbbIdBm = new ComboBox();
            panel6 = new Panel();
            btnLoadTKByBM = new Button();
            btnSelectVia = new Button();
            btnViaConfig = new Button();
            richTextBox1 = new RichTextBox();
            btnLoadInfoAdsUser = new Button();
            cbxLoadAccountGroup = new CheckBox();
            btnGetAllGroup = new Button();
            cbbGroup = new ComboBox();
            btnManagerBm = new Button();
            txtProxyVia = new TextBox();
            comboBox1 = new ComboBox();
            cbxProxy = new CheckBox();
            txtToken = new TextBox();
            txtCookieVia = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adsAccountTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1740, 637);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1740, 637);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1732, 609);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1726, 603);
            panel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(adsAccountTable);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 187);
            panel5.Name = "panel5";
            panel5.Size = new Size(1726, 416);
            panel5.TabIndex = 2;
            // 
            // adsAccountTable
            // 
            adsAccountTable.AllowUserToAddRows = false;
            adsAccountTable.AllowUserToOrderColumns = true;
            adsAccountTable.AllowUserToResizeRows = false;
            adsAccountTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            adsAccountTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            adsAccountTable.Columns.AddRange(new DataGridViewColumn[] { cbxTable, stt, id, nameTkqc, bill, status, role, country, currency, timezone, isPrepay, dateCreated, budget, threshold, credit, limit, pagePost, startTime, endTime, pixel, process });
            adsAccountTable.ContextMenuStrip = contextMenuStrip1;
            adsAccountTable.Dock = DockStyle.Fill;
            adsAccountTable.GridColor = SystemColors.Menu;
            adsAccountTable.Location = new Point(0, 0);
            adsAccountTable.Name = "adsAccountTable";
            adsAccountTable.RowHeadersVisible = false;
            adsAccountTable.RowHeadersWidth = 62;
            adsAccountTable.Size = new Size(1726, 416);
            adsAccountTable.TabIndex = 0;
            // 
            // cbxTable
            // 
            cbxTable.FillWeight = 32.51925F;
            cbxTable.HeaderText = "";
            cbxTable.MinimumWidth = 8;
            cbxTable.Name = "cbxTable";
            // 
            // stt
            // 
            stt.FillWeight = 63.5751953F;
            stt.HeaderText = "STT";
            stt.MinimumWidth = 8;
            stt.Name = "stt";
            stt.ReadOnly = true;
            // 
            // id
            // 
            id.FillWeight = 124.873894F;
            id.HeaderText = "ID";
            id.MinimumWidth = 8;
            id.Name = "id";
            // 
            // nameTkqc
            // 
            nameTkqc.FillWeight = 124.873894F;
            nameTkqc.HeaderText = "Tên";
            nameTkqc.MinimumWidth = 8;
            nameTkqc.Name = "nameTkqc";
            // 
            // bill
            // 
            bill.FillWeight = 110.822128F;
            bill.HeaderText = "Bill";
            bill.MinimumWidth = 8;
            bill.Name = "bill";
            // 
            // status
            // 
            status.FillWeight = 124.873894F;
            status.HeaderText = "Trạng thái";
            status.MinimumWidth = 8;
            status.Name = "status";
            // 
            // role
            // 
            role.FillWeight = 124.873894F;
            role.HeaderText = "Role";
            role.MinimumWidth = 8;
            role.Name = "role";
            // 
            // country
            // 
            country.FillWeight = 53.6021461F;
            country.HeaderText = "QG";
            country.MinimumWidth = 8;
            country.Name = "country";
            // 
            // currency
            // 
            currency.FillWeight = 51.74609F;
            currency.HeaderText = "TT";
            currency.MinimumWidth = 8;
            currency.Name = "currency";
            // 
            // timezone
            // 
            timezone.FillWeight = 124.873894F;
            timezone.HeaderText = "M.Giờ";
            timezone.MinimumWidth = 8;
            timezone.Name = "timezone";
            // 
            // isPrepay
            // 
            isPrepay.FillWeight = 71.06599F;
            isPrepay.HeaderText = "Prepay";
            isPrepay.MinimumWidth = 8;
            isPrepay.Name = "isPrepay";
            // 
            // dateCreated
            // 
            dateCreated.FillWeight = 124.873894F;
            dateCreated.HeaderText = "Ngày tạo";
            dateCreated.MinimumWidth = 8;
            dateCreated.Name = "dateCreated";
            // 
            // budget
            // 
            budget.FillWeight = 108.428223F;
            budget.HeaderText = "Ng.Sách";
            budget.MinimumWidth = 8;
            budget.Name = "budget";
            // 
            // threshold
            // 
            threshold.FillWeight = 108.428223F;
            threshold.HeaderText = "Ngưỡng";
            threshold.MinimumWidth = 8;
            threshold.Name = "threshold";
            // 
            // credit
            // 
            credit.FillWeight = 108.428223F;
            credit.HeaderText = "Thẻ";
            credit.MinimumWidth = 8;
            credit.Name = "credit";
            // 
            // limit
            // 
            limit.FillWeight = 108.428223F;
            limit.HeaderText = "Limit";
            limit.MinimumWidth = 8;
            limit.Name = "limit";
            // 
            // pagePost
            // 
            pagePost.FillWeight = 108.428223F;
            pagePost.HeaderText = "Page|Post";
            pagePost.MinimumWidth = 8;
            pagePost.Name = "pagePost";
            // 
            // startTime
            // 
            startTime.FillWeight = 108.428223F;
            startTime.HeaderText = "Start Time";
            startTime.MinimumWidth = 8;
            startTime.Name = "startTime";
            // 
            // endTime
            // 
            endTime.FillWeight = 108.428223F;
            endTime.HeaderText = "End Time";
            endTime.MinimumWidth = 8;
            endTime.Name = "endTime";
            // 
            // pixel
            // 
            pixel.FillWeight = 108.428223F;
            pixel.HeaderText = "Pixel";
            pixel.MinimumWidth = 8;
            pixel.Name = "pixel";
            // 
            // process
            // 
            process.HeaderText = "Tiến Trình";
            process.MinimumWidth = 8;
            process.Name = "process";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnLoadAgain, btnOnOffCamp, btnClearOptions, btnSelectedOptions, btnCheckCredit, btnAddCredit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(160, 184);
            // 
            // btnLoadAgain
            // 
            btnLoadAgain.Image = Properties.Resources.refresh;
            btnLoadAgain.Name = "btnLoadAgain";
            btnLoadAgain.Size = new Size(159, 30);
            btnLoadAgain.Text = "Load lại";
            // 
            // btnOnOffCamp
            // 
            btnOnOffCamp.Image = Properties.Resources.switch_on;
            btnOnOffCamp.Name = "btnOnOffCamp";
            btnOnOffCamp.Size = new Size(159, 30);
            btnOnOffCamp.Text = "Bật | Tắt Camp";
            // 
            // btnClearOptions
            // 
            btnClearOptions.DropDown = contextMenuStrip3;
            btnClearOptions.Image = Properties.Resources.trash;
            btnClearOptions.Name = "btnClearOptions";
            btnClearOptions.Size = new Size(159, 30);
            btnClearOptions.Text = "Xoá dữ liệu";
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(24, 24);
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { btnClearSelectedData, btnClearAllData });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.OwnerItem = btnClearOptions;
            contextMenuStrip3.Size = new Size(207, 48);
            // 
            // btnClearSelectedData
            // 
            btnClearSelectedData.Name = "btnClearSelectedData";
            btnClearSelectedData.Size = new Size(206, 22);
            btnClearSelectedData.Text = "Xoá dữ liệu được bôi đen";
            btnClearSelectedData.Click += btnClearSelectedData_Click;
            // 
            // btnClearAllData
            // 
            btnClearAllData.Name = "btnClearAllData";
            btnClearAllData.Size = new Size(206, 22);
            btnClearAllData.Text = "Xoá hết dữ liệu";
            btnClearAllData.Click += btnClearAllData_Click;
            // 
            // btnSelectedOptions
            // 
            btnSelectedOptions.DropDown = contextMenuStrip2;
            btnSelectedOptions.Image = Properties.Resources.touchscreen;
            btnSelectedOptions.Name = "btnSelectedOptions";
            btnSelectedOptions.Size = new Size(159, 30);
            btnSelectedOptions.Text = "Chọn dữ liệu";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(24, 24);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { btnSelectedBlackData, btnSelectedAllData, btnUnselectedBlackData, btnUnselectedAll });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.OwnerItem = btnSelectedOptions;
            contextMenuStrip2.Size = new Size(231, 92);
            // 
            // btnSelectedBlackData
            // 
            btnSelectedBlackData.Name = "btnSelectedBlackData";
            btnSelectedBlackData.Size = new Size(230, 22);
            btnSelectedBlackData.Text = "Chọn dữ liệu được bôi đen";
            btnSelectedBlackData.Click += btnSelectedBlackData_Click;
            // 
            // btnSelectedAllData
            // 
            btnSelectedAllData.Name = "btnSelectedAllData";
            btnSelectedAllData.Size = new Size(230, 22);
            btnSelectedAllData.Text = "Chọn tất cả dữ liệu";
            btnSelectedAllData.Click += btnSelectedAllData_Click;
            // 
            // btnUnselectedBlackData
            // 
            btnUnselectedBlackData.Name = "btnUnselectedBlackData";
            btnUnselectedBlackData.Size = new Size(230, 22);
            btnUnselectedBlackData.Text = "Bỏ chọn dữ liệu được bôi đen";
            btnUnselectedBlackData.Click += btnUnselectedBlackData_Click;
            // 
            // btnUnselectedAll
            // 
            btnUnselectedAll.Name = "btnUnselectedAll";
            btnUnselectedAll.Size = new Size(230, 22);
            btnUnselectedAll.Text = "Bỏ chọn tất cả";
            btnUnselectedAll.Click += btnUnselectedAll_Click;
            // 
            // btnCheckCredit
            // 
            btnCheckCredit.Image = Properties.Resources.card;
            btnCheckCredit.Name = "btnCheckCredit";
            btnCheckCredit.Size = new Size(159, 30);
            btnCheckCredit.Text = "Check thẻ";
            btnCheckCredit.Click += btnCheckCredit_Click;
            // 
            // btnAddCredit
            // 
            btnAddCredit.Image = Properties.Resources.card;
            btnAddCredit.Name = "btnAddCredit";
            btnAddCredit.Size = new Size(159, 30);
            btnAddCredit.Text = "Add thẻ";
            btnAddCredit.Click += btnAddCredit_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(button10);
            panel4.Controls.Add(button9);
            panel4.Controls.Add(button8);
            panel4.Controls.Add(button7);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(btnCheckTKLT);
            panel4.Controls.Add(btnDeleteCredit);
            panel4.Controls.Add(btnAddCreditOptions);
            panel4.Controls.Add(btnCheckXMSDT);
            panel4.Controls.Add(txtSearchIdTkqc);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 114);
            panel4.Name = "panel4";
            panel4.Size = new Size(1726, 73);
            panel4.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnClearAllDraft);
            panel7.Controls.Add(button19);
            panel7.Controls.Add(button18);
            panel7.Controls.Add(button17);
            panel7.Controls.Add(button16);
            panel7.Controls.Add(button15);
            panel7.Controls.Add(button14);
            panel7.Controls.Add(button13);
            panel7.Controls.Add(btnCampPe);
            panel7.Controls.Add(btnCampBpOptions);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(946, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(780, 73);
            panel7.TabIndex = 11;
            // 
            // btnClearAllDraft
            // 
            btnClearAllDraft.Location = new Point(671, 42);
            btnClearAllDraft.Name = "btnClearAllDraft";
            btnClearAllDraft.Size = new Size(106, 25);
            btnClearAllDraft.TabIndex = 38;
            btnClearAllDraft.Text = "Xoá All Nháp";
            btnClearAllDraft.UseVisualStyleBackColor = true;
            btnClearAllDraft.Click += btnClearAllDraft_Click;
            // 
            // button19
            // 
            button19.BackColor = Color.White;
            button19.BackgroundImageLayout = ImageLayout.None;
            button19.FlatAppearance.BorderColor = Color.Red;
            button19.FlatStyle = FlatStyle.Popup;
            button19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button19.ForeColor = Color.Red;
            button19.Location = new Point(703, 3);
            button19.Margin = new Padding(0);
            button19.Name = "button19";
            button19.Size = new Size(75, 23);
            button19.TabIndex = 37;
            button19.Text = "STOP";
            button19.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            button18.Location = new Point(621, 3);
            button18.Name = "button18";
            button18.Size = new Size(72, 23);
            button18.TabIndex = 36;
            button18.Text = "Xoá Camp";
            button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            button17.Location = new Point(540, 3);
            button17.Name = "button17";
            button17.Size = new Size(75, 23);
            button17.TabIndex = 35;
            button17.Text = "Public All";
            button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Location = new Point(467, 3);
            button16.Name = "button16";
            button16.Size = new Size(67, 23);
            button16.TabIndex = 34;
            button16.Text = "Set GHCT";
            button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            button15.Location = new Point(386, 3);
            button15.Name = "button15";
            button15.Size = new Size(75, 23);
            button15.TabIndex = 33;
            button15.Text = "Set Target";
            button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Location = new Point(305, 3);
            button14.Name = "button14";
            button14.Size = new Size(75, 23);
            button14.TabIndex = 32;
            button14.Text = "Set Budget";
            button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(224, 3);
            button13.Name = "button13";
            button13.Size = new Size(75, 23);
            button13.TabIndex = 31;
            button13.Text = "Set Time";
            button13.UseVisualStyleBackColor = true;
            // 
            // btnCampPe
            // 
            btnCampPe.Location = new Point(143, 3);
            btnCampPe.Name = "btnCampPe";
            btnCampPe.Size = new Size(75, 23);
            btnCampPe.TabIndex = 30;
            btnCampPe.Text = "Camp-PE";
            btnCampPe.UseVisualStyleBackColor = true;
            btnCampPe.Click += btnCampPe_Click;
            // 
            // btnCampBpOptions
            // 
            btnCampBpOptions.Location = new Point(62, 3);
            btnCampBpOptions.Name = "btnCampBpOptions";
            btnCampBpOptions.Size = new Size(75, 23);
            btnCampBpOptions.TabIndex = 29;
            btnCampBpOptions.Text = "Camp-BP";
            btnCampBpOptions.UseVisualStyleBackColor = true;
            btnCampBpOptions.Click += btnCampBpOptions_Click;
            // 
            // button10
            // 
            button10.Location = new Point(847, 3);
            button10.Name = "button10";
            button10.Size = new Size(93, 23);
            button10.TabIndex = 10;
            button10.Text = "Open MOMO";
            button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(766, 3);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 9;
            button9.Text = "Bật TT";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(694, 3);
            button8.Name = "button8";
            button8.Size = new Size(66, 23);
            button8.TabIndex = 8;
            button8.Text = "OpenBill";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(608, 3);
            button7.Name = "button7";
            button7.Size = new Size(80, 23);
            button7.TabIndex = 7;
            button7.Text = "OpenCamp";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(548, 3);
            button6.Name = "button6";
            button6.Size = new Size(54, 23);
            button6.TabIndex = 6;
            button6.Text = "Tax";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(0, 3);
            button5.Name = "button5";
            button5.Size = new Size(56, 23);
            button5.TabIndex = 5;
            button5.Text = "Page";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnCheckTKLT
            // 
            btnCheckTKLT.Location = new Point(474, 3);
            btnCheckTKLT.Name = "btnCheckTKLT";
            btnCheckTKLT.Size = new Size(68, 23);
            btnCheckTKLT.TabIndex = 4;
            btnCheckTKLT.Text = "Chk TKLT";
            btnCheckTKLT.UseVisualStyleBackColor = true;
            btnCheckTKLT.Click += btnCheckTKLT_Click;
            // 
            // btnDeleteCredit
            // 
            btnDeleteCredit.Location = new Point(409, 3);
            btnDeleteCredit.Name = "btnDeleteCredit";
            btnDeleteCredit.Size = new Size(59, 23);
            btnDeleteCredit.TabIndex = 3;
            btnDeleteCredit.Text = "Xoá thẻ";
            btnDeleteCredit.UseVisualStyleBackColor = true;
            btnDeleteCredit.Click += btnDeleteCredit_Click;
            // 
            // btnAddCreditOptions
            // 
            btnAddCreditOptions.Location = new Point(339, 3);
            btnAddCreditOptions.Name = "btnAddCreditOptions";
            btnAddCreditOptions.Size = new Size(64, 23);
            btnAddCreditOptions.TabIndex = 2;
            btnAddCreditOptions.Text = "Add Thẻ";
            btnAddCreditOptions.UseVisualStyleBackColor = true;
            btnAddCreditOptions.Click += btnAddCreditOptions_Click;
            // 
            // btnCheckXMSDT
            // 
            btnCheckXMSDT.Location = new Point(241, 3);
            btnCheckXMSDT.Name = "btnCheckXMSDT";
            btnCheckXMSDT.Size = new Size(92, 23);
            btnCheckXMSDT.TabIndex = 1;
            btnCheckXMSDT.Text = "Chk XMSDT";
            btnCheckXMSDT.UseVisualStyleBackColor = true;
            btnCheckXMSDT.Click += btnCheckXMSDT_Click;
            // 
            // txtSearchIdTkqc
            // 
            txtSearchIdTkqc.Location = new Point(0, 44);
            txtSearchIdTkqc.Name = "txtSearchIdTkqc";
            txtSearchIdTkqc.PlaceholderText = "Tìm theo ID";
            txtSearchIdTkqc.Size = new Size(150, 23);
            txtSearchIdTkqc.TabIndex = 0;
            txtSearchIdTkqc.TextChanged += txtSearchIdTkqc_TextChanged;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cbbIdBm);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(btnLoadInfoAdsUser);
            panel3.Controls.Add(cbxLoadAccountGroup);
            panel3.Controls.Add(btnGetAllGroup);
            panel3.Controls.Add(cbbGroup);
            panel3.Controls.Add(btnManagerBm);
            panel3.Controls.Add(txtProxyVia);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(cbxProxy);
            panel3.Controls.Add(txtToken);
            panel3.Controls.Add(txtCookieVia);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1726, 114);
            panel3.TabIndex = 0;
            // 
            // cbbIdBm
            // 
            cbbIdBm.FormattingEnabled = true;
            cbbIdBm.Location = new Point(69, 40);
            cbbIdBm.Name = "cbbIdBm";
            cbbIdBm.Size = new Size(206, 23);
            cbbIdBm.TabIndex = 23;
            cbbIdBm.Text = "None";
            // 
            // panel6
            // 
            panel6.Controls.Add(btnLoadTKByBM);
            panel6.Controls.Add(btnSelectVia);
            panel6.Controls.Add(btnViaConfig);
            panel6.Controls.Add(richTextBox1);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(1102, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(622, 112);
            panel6.TabIndex = 22;
            // 
            // btnLoadTKByBM
            // 
            btnLoadTKByBM.Location = new Point(486, 51);
            btnLoadTKByBM.Name = "btnLoadTKByBM";
            btnLoadTKByBM.Size = new Size(126, 50);
            btnLoadTKByBM.TabIndex = 19;
            btnLoadTKByBM.Text = "Load TK";
            btnLoadTKByBM.UseVisualStyleBackColor = true;
            btnLoadTKByBM.Click += btnLoadTKByBM_Click;
            // 
            // btnSelectVia
            // 
            btnSelectVia.Location = new Point(541, 10);
            btnSelectVia.Name = "btnSelectVia";
            btnSelectVia.Size = new Size(71, 35);
            btnSelectVia.TabIndex = 18;
            btnSelectVia.Text = "Open Via";
            btnSelectVia.UseVisualStyleBackColor = true;
            btnSelectVia.Click += btnSelectVia_Click;
            // 
            // btnViaConfig
            // 
            btnViaConfig.Location = new Point(486, 10);
            btnViaConfig.Name = "btnViaConfig";
            btnViaConfig.Size = new Size(49, 35);
            btnViaConfig.TabIndex = 17;
            btnViaConfig.Text = "Via";
            btnViaConfig.UseVisualStyleBackColor = true;
            btnViaConfig.Click += btnViaConfig_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(17, 11);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(463, 90);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // btnLoadInfoAdsUser
            // 
            btnLoadInfoAdsUser.Location = new Point(994, 70);
            btnLoadInfoAdsUser.Name = "btnLoadInfoAdsUser";
            btnLoadInfoAdsUser.Size = new Size(102, 23);
            btnLoadInfoAdsUser.TabIndex = 20;
            btnLoadInfoAdsUser.Text = "Load TK User";
            btnLoadInfoAdsUser.UseVisualStyleBackColor = true;
            btnLoadInfoAdsUser.Click += btnLoadInfoAdsUser_Click;
            // 
            // cbxLoadAccountGroup
            // 
            cbxLoadAccountGroup.AutoSize = true;
            cbxLoadAccountGroup.Location = new Point(362, 73);
            cbxLoadAccountGroup.Name = "cbxLoadAccountGroup";
            cbxLoadAccountGroup.Size = new Size(104, 19);
            cbxLoadAccountGroup.TabIndex = 18;
            cbxLoadAccountGroup.Text = "Load TK Group";
            cbxLoadAccountGroup.UseVisualStyleBackColor = true;
            // 
            // btnGetAllGroup
            // 
            btnGetAllGroup.Location = new Point(281, 69);
            btnGetAllGroup.Name = "btnGetAllGroup";
            btnGetAllGroup.Size = new Size(75, 23);
            btnGetAllGroup.TabIndex = 17;
            btnGetAllGroup.Text = "Group";
            btnGetAllGroup.UseVisualStyleBackColor = true;
            btnGetAllGroup.Click += btnGetAllGroup_Click;
            // 
            // cbbGroup
            // 
            cbbGroup.FormattingEnabled = true;
            cbbGroup.Location = new Point(69, 69);
            cbbGroup.Name = "cbbGroup";
            cbbGroup.Size = new Size(206, 23);
            cbbGroup.TabIndex = 16;
            cbbGroup.Text = "Nhấn nút để chọn Group";
            // 
            // btnManagerBm
            // 
            btnManagerBm.Location = new Point(1021, 10);
            btnManagerBm.Name = "btnManagerBm";
            btnManagerBm.Size = new Size(75, 53);
            btnManagerBm.TabIndex = 11;
            btnManagerBm.Text = "QL BM";
            btnManagerBm.UseVisualStyleBackColor = true;
            btnManagerBm.Click += btnManagerBm_Click;
            // 
            // txtProxyVia
            // 
            txtProxyVia.Location = new Point(858, 11);
            txtProxyVia.Name = "txtProxyVia";
            txtProxyVia.PlaceholderText = "127.0.0.0:6000";
            txtProxyVia.Size = new Size(157, 23);
            txtProxyVia.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ipv4", "ipv6" });
            comboBox1.Location = new Point(790, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(62, 23);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "ipv4";
            // 
            // cbxProxy
            // 
            cbxProxy.AutoSize = true;
            cbxProxy.Location = new Point(728, 13);
            cbxProxy.Name = "cbxProxy";
            cbxProxy.Size = new Size(56, 19);
            cbxProxy.TabIndex = 8;
            cbxProxy.Text = "Proxy";
            cbxProxy.UseVisualStyleBackColor = true;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(281, 40);
            txtToken.Name = "txtToken";
            txtToken.PlaceholderText = "Access Token";
            txtToken.Size = new Size(734, 23);
            txtToken.TabIndex = 7;
            // 
            // txtCookieVia
            // 
            txtCookieVia.Location = new Point(477, 11);
            txtCookieVia.Name = "txtCookieVia";
            txtCookieVia.PlaceholderText = "Cookie";
            txtCookieVia.Size = new Size(234, 23);
            txtCookieVia.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(379, 11);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "2FA";
            textBox4.Size = new Size(92, 23);
            textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(281, 11);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Password";
            textBox3.Size = new Size(92, 23);
            textBox3.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(69, 11);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Uid";
            textBox1.Size = new Size(206, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 45);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 1;
            label2.Text = "BM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 16);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 0;
            label1.Text = "VIA";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1732, 609);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Schedule";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1732, 609);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Config";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1740, 637);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Auto Camp - WOLF META";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adsAccountTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip3.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox txtCookieVia;
        private TextBox txtToken;
        private CheckBox cbxProxy;
        private ComboBox comboBox1;
        private TextBox txtProxyVia;
        private Button btnManagerBm;
        private Panel panel5;
        private Panel panel4;
        private DataGridView adsAccountTable;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnLoadAgain;
        private ToolStripMenuItem btnOnOffCamp;
        private CheckBox cbxLoadAccountGroup;
        private Button btnGetAllGroup;
        private ComboBox cbbGroup;
        private Button btnLoadInfoAdsUser;
        private Panel panel6;
        private Button btnLoadTKByBM;
        private Button btnSelectVia;
        private Button btnViaConfig;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem btnClearOptions;
        private ComboBox cbbIdBm;
        private ToolStripMenuItem btnSelectedOptions;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem btnSelectedBlackData;
        private ToolStripMenuItem btnSelectedAllData;
        private ToolStripMenuItem btnUnselectedBlackData;
        private ToolStripMenuItem btnUnselectedAll;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem btnClearSelectedData;
        private ToolStripMenuItem btnClearAllData;
        private ToolStripMenuItem btnCheckCredit;
        private TextBox txtSearchIdTkqc;
        private Button btnCheckXMSDT;
        private Button btnAddCreditOptions;
        private Button btnDeleteCredit;
        private Button btnCheckTKLT;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Panel panel7;
        private Button button19;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button btnCampPe;
        private Button btnCampBpOptions;
        private DataGridViewCheckBoxColumn cbxTable;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nameTkqc;
        private DataGridViewTextBoxColumn bill;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn role;
        private DataGridViewTextBoxColumn country;
        private DataGridViewTextBoxColumn currency;
        private DataGridViewTextBoxColumn timezone;
        private DataGridViewTextBoxColumn isPrepay;
        private DataGridViewTextBoxColumn dateCreated;
        private DataGridViewTextBoxColumn budget;
        private DataGridViewTextBoxColumn threshold;
        private DataGridViewTextBoxColumn credit;
        private DataGridViewTextBoxColumn limit;
        private DataGridViewTextBoxColumn pagePost;
        private DataGridViewTextBoxColumn startTime;
        private DataGridViewTextBoxColumn endTime;
        private DataGridViewTextBoxColumn pixel;
        private DataGridViewTextBoxColumn process;
        private Button btnClearAllDraft;
        private ToolStripMenuItem btnAddCredit;
    }
}
