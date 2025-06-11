namespace AutoCamp.ui
{
    partial class AddCreditOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCreditOptionsForm));
            panel1 = new Panel();
            label4 = new Label();
            cbbTimezone = new ComboBox();
            label3 = new Label();
            cbbCurrency = new ComboBox();
            cbbCountry = new ComboBox();
            label2 = new Label();
            cbChangeInfo = new CheckBox();
            btnSaveCreditData = new Button();
            label1 = new Label();
            txtCreditData = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbbTimezone);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbbCurrency);
            panel1.Controls.Add(cbbCountry);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbChangeInfo);
            panel1.Controls.Add(btnSaveCreditData);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCreditData);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(697, 367);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 118);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 10;
            label4.Text = "Múi giờ";
            // 
            // cbbTimezone
            // 
            cbbTimezone.FormattingEnabled = true;
            cbbTimezone.Items.AddRange(new object[] { "(GMT -10:00) - Hawaii - {Pacific/Honolulu}", "(GMT -09:00) - Alaska - {America/Anchorage}", "(GMT -08:00) - Tijuana Time - {America/Tijuana}", "(GMT -08:00) - Vancouver - {America/Vancouver}", "(GMT -08:00) - Pacific - {America/Los_Angeles}", "(GMT -07:00) - Mazatlan - {America/Mazatlan}", "(GMT -07:00) - Hermosillo - {America/Hermosillo}", "(GMT -07:00) - Edmonton - {America/Edmonton}", "(GMT -07:00) - Dawson - {America/Dawson}", "(GMT -07:00) - Dawson Creek - {America/Dawson_Creek}", "(GMT -07:00) - Mountain Standard Time - {America/Phoenix}", "(GMT -07:00) - Mountain - {America/Denver}", "(GMT -06:00) - Winnipeg - {America/Winnipeg}", "(GMT -06:00) - El Salvador - {America/El_Salvador}", "(GMT -06:00) - Managua - {America/Managua}", "(GMT -06:00) - Mexico City - {America/Mexico_City}", "(GMT -06:00) - Tegucigalpa - {America/Tegucigalpa}", "(GMT -06:00) - Guatemala - {America/Guatemala}", "(GMT -06:00) - Galapagos - {Pacific/Galapagos}", "(GMT -06:00) - Costa Rica - {America/Costa_Rica}", "(GMT -06:00) - Regina - {America/Regina}", "(GMT -06:00) - Rainy River - {America/Rainy_River}", "(GMT -06:00) - Central - {America/Chicago}", "(GMT -05:00) - Detroit - {America/Detroit}", "(GMT -05:00) - Lima - {America/Lima}", "(GMT -05:00) - Panama - {America/Panama}", "(GMT -05:00) - Jamaica - {America/Jamaica}", "(GMT -05:00) - Guayaquil - {America/Guayaquil}", "(GMT -05:00) - Bogota - {America/Bogota}", "(GMT -05:00) - Easter Island- {Pacific/Easter}", "(GMT -05:00) - Toronto - {America/Toronto}", "(GMT -05:00) - Iqaluit - {America/Iqaluit}", "(GMT -05:00) - Atikokan - {America/Atikokan}", "(GMT -05:00) - Nassau - {America/Nassau}", "(GMT -05:00) - Eastern - {America/New_York}", "(GMT -04:00) - Caracas - {America/Caracas}", "(GMT -04:00) - Port of Spain - {America/Port_of_Spain}", "(GMT -04:00) - Puerto Rico - {America/Puerto_Rico}", "(GMT -04:00) - Santo Domingo - {America/Santo_Domingo}", "(GMT -04:00) - Halifax - {America/Halifax}", "(GMT -04:00) - Blanc-Sablon - {America/Blanc-Sablon}", "(GMT -04:00) - Campo Grande - {America/Campo_Grande}", "(GMT -04:00) - La Paz - {America/La_Paz}", "(GMT -03:30) - St Johns - {America/St_Johns}", "(GMT -03:00) - Montevideo - {America/Montevideo}", "(GMT -03:00) - Asuncion - {America/Asuncion}", "(GMT -03:00) - Santiago - {America/Santiago}", "(GMT -03:00) - Sao Paulo - {America/Sao_Paulo}", "(GMT -03:00) - Belem - {America/Belem}", "(GMT -03:00) - Salta - {America/Argentina/Salta}", "(GMT -03:00) - Buenos Aires - {America/Argentina/Buenos_Aires}", "(GMT -03:00) - San Luis - {America/Argentina/San_Luis}", "(GMT -02:00) - Noronha - {America/Noronha}", "(GMT -01:00) - Waktu Azores - {Atlantic/Azores}", "(GMT +00:00) - UTC Time - {UTC}", "(GMT +00:00) - Ouagadougou - {Africa/Ouagadougou}", "(GMT +00:00) - Lisbon - {Europe/Lisbon}", "(GMT +00:00) - Reykjavik - {Atlantic/Reykjavik}", "(GMT +00:00) - Dublin - {Europe/Dublin}", "(GMT +00:00) - Accra - {Africa/Accra}", "(GMT +00:00) - London - {Europe/London}", "(GMT +00:00) - Canary - {Atlantic/Canary}", "(GMT +01:00) - Tunis - {Africa/Tunis}", "(GMT +01:00) - Bratislava - {Europe/Bratislava}", "(GMT +01:00) - Ljubljana - {Europe/Ljubljana}", "(GMT +01:00) - Stockholm - {Europe/Stockholm}", "(GMT +01:00) - Belgrade - {Europe/Belgrade}", "(GMT +01:00) - Warsaw - {Europe/Warsaw}", "(GMT +01:00) - Oslo - {Europe/Oslo}", "(GMT +01:00) - Amsterdam - {Europe/Amsterdam}", "(GMT +01:00) - Lagos - {Africa/Lagos}", "(GMT +01:00) - Malta - {Europe/Malta}", "(GMT +01:00) - Skopje - {Europe/Skopje}", "(GMT +01:00) - Casablanca - {Africa/Casablanca}", "(GMT +01:00) - Luxembourg - {Europe/Luxembourg}", "(GMT +01:00) - Rome - {Europe/Rome}", "(GMT +01:00) - Budapest - {Europe/Budapest}", "(GMT +01:00) - Zagreb - {Europe/Zagreb}", "(GMT +01:00) - Paris - {Europe/Paris}", "(GMT +01:00) - Madrid - {Europe/Madrid}", "(GMT +01:00) - Copenhagen - {Europe/Copenhagen}", "(GMT +01:00) - Berlin - {Europe/Berlin}", "(GMT +01:00) - Prague - {Europe/Prague}", "(GMT +01:00) - Zurich - {Europe/Zurich}", "(GMT +01:00) - Brussels - {Europe/Brussels}", "(GMT +01:00) - Sarajevo - {Europe/Sarajevo}", "(GMT +01:00) - Vienna - {Europe/Vienna}", "(GMT +02:00) - Chisinau - {Europe/Chisinau}", "(GMT +02:00) - Johannesburg - {Africa/Johannesburg}", "(GMT +02:00) - Kiev - {Europe/Kiev}", "(GMT +02:00) - Kaliningrad - {Europe/Kaliningrad}", "(GMT +02:00) - Bucharest - {Europe/Bucharest}", "(GMT +02:00) - Gaza - {Asia/Gaza}", "(GMT +02:00) - Riga - {Europe/Riga}", "(GMT +02:00) - Vilnius - {Europe/Vilnius}", "(GMT +02:00) - Beirut - {Asia/Beirut}", "(GMT +02:00) - Amman - {Asia/Amman}", "(GMT +02:00) - Jerusalem - {Asia/Jerusalem}", "(GMT +02:00) - Athens - {Europe/Athens}", "(GMT +02:00) - Helsinki - {Europe/Helsinki}", "(GMT +02:00) - Cairo - {Africa/Cairo}", "(GMT +02:00) - Tallinn - {Europe/Tallinn}", "(GMT +02:00) - Nicosia - {Asia/Nicosia}", "(GMT +02:00) - Sofia - {Europe/Sofia}", "(GMT +03:00) - Istanbul - {Europe/Istanbul}", "(GMT +03:00) - Riyadh - {Asia/Riyadh}", "(GMT +03:00) - Moscow - {Europe/Moscow}", "(GMT +03:00) - Qatar - {Asia/Qatar}", "(GMT +03:00) - Kuwait - {Asia/Kuwait}", "(GMT +03:00) - Nairobi - {Africa/Nairobi}", "(GMT +03:00) - Baghdad - {Asia/Baghdad}", "(GMT +03:00) - Bahrain - {Asia/Bahrain}", "(GMT +04:00) - Yerevan - {Asia/Yerevan}", "(GMT +04:00) - Baku - {Asia/Baku}", "(GMT +04:00) - Samara - {Europe/Samara}", "(GMT +04:00) - Muscat - {Asia/Muscat}", "(GMT +04:00) - Mauritius - {Indian/Mauritius}", "(GMT +04:00) - Dubai - {Asia/Dubai}", "(GMT +05:00) - Yekaterinburg - {Asia/Yekaterinburg}", "(GMT +05:00) - Karachi - {Asia/Karachi}", "(GMT +05:00) - Maldives - {Indian/Maldives}", "(GMT +05:30) - Colombo - {Asia/Colombo}", "(GMT +05:30) - Kolkata - {Asia/Kolkata}", "(GMT +05:45) - Kathmandu - {Asia/Kathmandu}", "(GMT +06:00) - Omsk - {Asia/Omsk}", "(GMT +06:00) - Dhaka - {Asia/Dhaka}", "(GMT +07:00) - Ho Chi Minh - {Asia/Ho_Chi_Minh}", "(GMT +07:00) - Bangkok - {Asia/Bangkok}", "(GMT +07:00) - Krasnoyarsk - {Asia/Krasnoyarsk}", "(GMT +07:00) - Jakarta - {Asia/Jakarta}", "(GMT +08:00) - Taipei - {Asia/Taipei}", "(GMT +08:00) - Singapore - {Asia/Singapore}", "(GMT +08:00) - Irkutsk - {Asia/Irkutsk}", "(GMT +08:00) - Manila - {Asia/Manila}", "(GMT +08:00) - Kuala Lumpur - {Asia/Kuala_Lumpur}", "(GMT +08:00) - Makassar - {Asia/Makassar}", "(GMT +08:00) - Hong Kong - {Asia/Hong_Kong}", "(GMT +08:00) - Beijing - {Asia/Shanghai}", "(GMT +08:00) - Perth - {Australia/Perth}", "(GMT +09:00) - Yakutsk - {Asia/Yakutsk}", "(GMT +09:00) - Seoul - {Asia/Seoul}", "(GMT +09:00) - Tokyo - {Asia/Tokyo}", "(GMT +09:00) - Jayapura - {Asia/Jayapura}", "(GMT +10:00) - Sydney - {Asia/Vladivostok}", "(GMT +10:30) - Broken Hill - {Australia/Broken_Hill}", "(GMT +11:00) - Melbourne - {Australia/Melbourne}", "(GMT +11:00) - Magadan - {Asia/Magadan}", "(GMT +11:00) - Sydney - {Australia/Sydney}", "(GMT +12:00) - Kamchatka - {Asia/Kamchatka}", "(GMT +13:00) - Auckland - {Pacific/Auckland}" });
            cbbTimezone.Location = new Point(378, 115);
            cbbTimezone.Name = "cbbTimezone";
            cbbTimezone.Size = new Size(307, 23);
            cbbTimezone.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 89);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 7;
            label3.Text = "Tiền Tệ";
            // 
            // cbbCurrency
            // 
            cbbCurrency.FormattingEnabled = true;
            cbbCurrency.Items.AddRange(new object[] { "{1}UAE Dirham (AED)", "{2}Argentine Peso (ARS)", "{3}Australian Dollar (AUD)", "{4}Bangladeshi Taka (BDT)", "{5}Bolivian Boliviano (BOB)", "{6}Brazilian Real (BRL)", "{7}Canadian Dollar (CAD)", "{8}Swiss Franc (CHF)", "{9}Chilean Peso (CLP)", "{10}Chinese Yuan (CNY)", "{11}Colombian Peso (COP)", "{12}Costa Rican Col?n (CRC)", "{13}Czech Koruna (CZK)", "{14}Danish Krone (DKK)", "{15}Algerian Dinar (DZD)", "{16}Egyptian Pound (EGP)", "{17}Euro (EUR)", "{18}British Pound (GBP)", "{19}Guatemalan Quetzal (GTQ)", "{20}Hong Kong Dollar (HKD)", "{21}Honduran Lempira (HNL)", "{22}Hungarian Forint (HUF)", "{23}Indonesian Rupiah (IDR)", "{24}Israeli New Shekel (ILS)", "{25}Indian Rupee (INR)", "{26}Iceland Krona (ISK)", "{27}Japanese Yen (JPY)", "{28}Kenyan Shilling (KES)", "{29}Korean Won (KRW)", "{30}Macau Patacas (MOP)", "{31}Mexican Peso (MXN)", "{32}Malaysian Ringgit (MYR)", "{33}Nigerian Naira (NGN)", "{34}Nicaraguan Cordoba (NIO)", "{35}Norwegian Krone (NOK)", "{36}New Zealand Dollar (NZD)", "{37}Peruvian Nuevo Sol (PEN)", "{38}Philippine Peso (PHP)", "{39}Pakistani Rupee (PKR)", "{40}Polish Zloty (PLN)", "{41}Paraguayan Guarani (PYG)", "{42}Qatari Rials (QAR)", "{43}Romanian Leu (RON)", "{44}Russian Ruble (RUB)", "{45}Saudi Arabian Riyal (SAR)", "{46}Swedish Krona (SEK)", "{47}Singapore Dollar (SGD)", "{48}Thai Baht (THB)", "{49}Turkish Lira (TRY)", "{50}Taiwan Dollar (TWD)", "{51}US Dollars (USD)", "{52}Uruguay Peso (UYU)", "{53}Vietnamese Dong (VND)", "{54}South African Rand (ZAR)", "{55}Ucraina Hryvnia (UAH)" });
            cbbCurrency.Location = new Point(378, 86);
            cbbCurrency.Name = "cbbCurrency";
            cbbCurrency.Size = new Size(307, 23);
            cbbCurrency.TabIndex = 6;
            // 
            // cbbCountry
            // 
            cbbCountry.FormattingEnabled = true;
            cbbCountry.Items.AddRange(new object[] { "AD - Andorra", "AE - Các Tiểu vương quốc Ả Rập Thống nhất", "AF - Afghanistan", "AG - Antigua và Barbuda", "AI - Anguilla", "AL - Albania", "AM - Armenia", "AO - Angola", "AQ - Nam Cực", "AR - Argentina", "AS - American Samoa", "AT - Áo", "AU - Úc", "AW - Aruba", "AX - Quần đảo Åland", "AZ - Azerbaijan", "BA - Bosnia và Herzegovina", "BB - Barbados", "BD - Bangladesh", "BE - Bỉ", "BF - Burkina Faso", "BG - Bulgaria", "BH - Bahrain", "BI - Burundi", "BJ - Benin", "BL - Saint Barthélemy", "BM - Bermuda", "BN - Brunei", "BO - Bolivia", "BQ - Bonaire, Sint Eustatius và Saba", "BR - Brazil", "BS - Bahamas", "BT - Bhutan", "BV - Đảo Bouvet", "BW - Botswana", "BY - Belarus", "BZ - Belize", "CA - Canada", "CC - Quần đảo Cocos (Keeling)", "CD - Cộng hòa Dân chủ Congo", "CF - Cộng hòa Trung Phi", "CG - Cộng hòa Congo", "CH - Thụy Sĩ", "CI - Bờ Biển Ngà", "CK - Quần đảo Cook", "CL - Chile", "CM - Cameroon", "CN - Trung Quốc", "CO - Colombia", "CR - Costa Rica", "CU - Cuba", "CV - Cape Verde", "CW - Curaçao", "CX - Đảo Christmas", "CY - Síp", "CZ - Cộng hòa Séc", "DE - Đức", "DJ - Djibouti", "DK - Đan Mạch", "DM - Dominica", "DO - Cộng hòa Dominica", "DZ - Algeria", "EC - Ecuador", "EE - Estonia", "EG - Ai Cập", "EH - Tây Sahara", "ER - Eritrea", "ES - Tây Ban Nha", "ET - Ethiopia", "FI - Phần Lan", "FJ - Fiji", "FK - Quần đảo Falkland", "FM - Micronesia", "FO - Quần đảo Faroe", "FR - Pháp", "GA - Gabon", "GB - Vương quốc Anh", "GD - Grenada", "GE - Georgia", "GF - Guiana thuộc Pháp", "GG - Guernsey", "GH - Ghana", "GI - Gibraltar", "GL - Greenland", "GM - Gambia", "GN - Guinea", "GP - Guadeloupe", "GQ - Guinea Xích đạo", "GR - Hy Lạp", "GS - Nam Georgia và Quần đảo Nam Sandwich", "GT - Guatemala", "GU - Guam", "GW - Guinea-Bissau", "GY - Guyana", "HK - Hồng Kông", "HM - Quần đảo Heard và McDonald", "HN - Honduras", "HR - Croatia", "HT - Haiti", "HU - Hungary", "ID - Indonesia", "IE - Ireland", "IL - Israel", "IM - Đảo Man", "IN - Ấn Độ", "IO - Lãnh thổ Ấn Độ Dương thuộc Anh", "IQ - Iraq", "IR - Iran", "IS - Iceland", "IT - Ý", "JE - Jersey", "JM - Jamaica", "JO - Jordan", "JP - Nhật Bản", "KE - Kenya", "KG - Kyrgyzstan", "KH - Campuchia", "KI - Kiribati", "KM - Comoros", "KN - Saint Kitts và Nevis", "KP - Triều Tiên", "KR - Hàn Quốc", "KW - Kuwait", "KY - Quần đảo Cayman", "KZ - Kazakhstan", "LA - Lào", "LB - Lebanon", "LC - Saint Lucia", "LI - Liechtenstein", "LK - Sri Lanka", "LR - Liberia", "LS - Lesotho", "LT - Lithuania", "LU - Luxembourg", "LV - Latvia", "LY - Libya", "MA - Morocco", "MC - Monaco", "MD - Moldova", "ME - Montenegro", "MF - Saint Martin", "MG - Madagascar", "MH - Quần đảo Marshall", "MK - Macedonia Bắc", "ML - Mali", "MM - Myanmar", "MN - Mông Cổ", "MO - Macau", "MP - Quần đảo Bắc Mariana", "MQ - Martinique", "MR - Mauritania", "MS - Montserrat", "MT - Malta", "MU - Mauritius", "MV - Maldives", "MW - Malawi", "MX - Mexico", "MY - Malaysia", "MZ - Mozambique", "NA - Namibia", "NC - New Caledonia", "NE - Niger", "NF - Đảo Norfolk", "NG - Nigeria", "NI - Nicaragua", "NL - Hà Lan", "NO - Na Uy", "NP - Nepal", "NR - Nauru", "NU - Niue", "NZ - New Zealand", "OM - Oman", "PA - Panama", "PE - Peru", "PF - Polynesia thuộc Pháp", "PG - Papua New Guinea", "PH - Philippines", "PK - Pakistan", "PL - Ba Lan", "PM - Saint Pierre và Miquelon", "PN - Quần đảo Pitcairn", "PR - Puerto Rico", "PS - Palestine", "PT - Bồ Đào Nha", "PW - Palau", "PY - Paraguay", "QA - Qatar", "RE - Réunion", "RO - Romania", "RS - Serbia", "RU - Nga", "RW - Rwanda", "SA - Ả Rập Saudi", "SB - Quần đảo Solomon", "SC - Seychelles", "SD - Sudan", "SE - Thụy Điển", "SG - Singapore", "SH - Saint Helena", "SI - Slovenia", "SJ - Svalbard và Jan Mayen", "SK - Slovakia", "SL - Sierra Leone", "SM - San Marino", "SN - Senegal", "SO - Somalia", "SR - Suriname", "SS - Nam Sudan", "ST - São Tomé và Príncipe", "SV - El Salvador", "SX - Sint Maarten", "SY - Syria", "SZ - Eswatini (Swaziland)", "TC - Quần đảo Turks và Caicos", "TD - Chad", "TF - Lãnh thổ Nam Cực thuộc Pháp", "TG - Togo", "TH - Thái Lan", "TJ - Tajikistan", "TK - Tokelau", "TL - Đông Timor", "TM - Turkmenistan", "TN - Tunisia", "TO - Tonga", "TR - Thổ Nhĩ Kỳ", "TT - Trinidad và Tobago", "TV - Tuvalu", "TW - Đài Loan", "TZ - Tanzania", "UA - Ukraine", "UG - Uganda", "UM - Các đảo nhỏ xa trung tâm thuộc Mỹ", "US - Hoa Kỳ", "UY - Uruguay", "UZ - Uzbekistan", "VA - Vatican", "VC - Saint Vincent và Grenadines", "VE - Venezuela", "VG - Quần đảo Virgin thuộc Anh", "VI - Quần đảo Virgin thuộc Mỹ", "VN - Việt Nam", "VU - Vanuatu", "WF - Wallis và Futuna", "WS - Samoa", "YE - Yemen", "YT - Mayotte", "ZA - Nam Phi", "ZM - Zambia", "ZW - Zimbabwe" });
            cbbCountry.Location = new Point(378, 57);
            cbbCountry.Name = "cbbCountry";
            cbbCountry.Size = new Size(307, 23);
            cbbCountry.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 60);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "Quốc gia";
            // 
            // cbChangeInfo
            // 
            cbChangeInfo.AutoSize = true;
            cbChangeInfo.Location = new Point(317, 27);
            cbChangeInfo.Name = "cbChangeInfo";
            cbChangeInfo.Size = new Size(164, 19);
            cbChangeInfo.TabIndex = 4;
            cbChangeInfo.Text = "Change info trước khi add";
            cbChangeInfo.UseVisualStyleBackColor = true;
            // 
            // btnSaveCreditData
            // 
            btnSaveCreditData.Location = new Point(610, 330);
            btnSaveCreditData.Name = "btnSaveCreditData";
            btnSaveCreditData.Size = new Size(75, 28);
            btnSaveCreditData.TabIndex = 3;
            btnSaveCreditData.Text = "Lưu";
            btnSaveCreditData.UseVisualStyleBackColor = true;
            btnSaveCreditData.Click += btnSaveCreditData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Credit info";
            // 
            // txtCreditData
            // 
            txtCreditData.Location = new Point(8, 27);
            txtCreditData.Name = "txtCreditData";
            txtCreditData.Size = new Size(287, 331);
            txtCreditData.TabIndex = 1;
            txtCreditData.Text = "";
            // 
            // AddCreditOptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(697, 367);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddCreditOptionsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddCreditOptionsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private RichTextBox txtCreditData;
        private Button btnSaveCreditData;
        private CheckBox cbChangeInfo;
        private Label label2;
        private ComboBox cbbCountry;
        private Label label3;
        private Label label4;
        private ComboBox cbbTimezone;
        private ComboBox cbbCurrency;
    }
}