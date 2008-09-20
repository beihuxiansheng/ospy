/**
 * Copyright (C) 2006  Frode Hus <husfro@gmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using oSpyClassic;
using oSpyClassic.Parser;
using oSpyClassic.Net;
namespace oSpyClassic.Configuration
{
    public partial class ParserConfigDialog : Form
    {
        private PacketParser packetParser;
        public ParserConfigDialog(PacketParser packetParser)
        {
            InitializeComponent();
            this.packetParser = packetParser;
            populateParsers();
        }

        private void populateParsers() {
            comboParsers.Items.Clear();
            foreach (TransactionFactory fac in packetParser.Factories) {
                comboParsers.Items.Add(fac.Name());
            }
        }
        private void saveSettings() {
            if (comboParsers.Text.Equals(""))
                return;
            string factory = comboParsers.Text;
            Setting setting;
            List<Setting> settings = new List<Setting>();
            foreach (DataGridViewRow row in dgSettings.Rows) {
                setting = new Setting();
                setting.Property = row.Cells[0].Value.ToString();
                setting.Value = row.Cells[1].Value.ToString();
                settings.Add(setting);
            }
            ParserConfiguration.Settings.Add(factory, settings);
        }


        private void btnSave_Click(object sender, EventArgs e) {
           
            saveSettings();
        }
    }
}