using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzsikaTS_Rendező
{
    public partial class RuleEditor : Form
    {
        Rule _rule;
        public RuleEditor(Rule rule)
        {
            InitializeComponent();
            _rule = rule;
        }

        private void RuleEditor_Load(object sender, EventArgs e)
        {

            tbRuleValue.Text = _rule.Value;
            cbRuleMode.Items.AddRange(Enum.GetValues(typeof(Rule.RuleMode)).OfType<object>().ToArray());
            cbRuleMode.SelectedItem = _rule.Mode;
            cbRuleTarget.Items.AddRange(Enum.GetValues(typeof(Rule.RuleTarget)).OfType<object>().ToArray());
            cbRuleTarget.SelectedItem = _rule.Target;
            _rule.Enabled = true;
        }

        private void cbRuleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rule.Mode = (Rule.RuleMode)cbRuleMode.SelectedItem;
        }

        private void cbRuleTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rule.Target = (Rule.RuleTarget)cbRuleTarget.SelectedItem;
        }

        private void tbRuleValue_TextChanged(object sender, EventArgs e)
        {
            _rule.Value = tbRuleValue.Text.ToUpperFirstLetter();
        }

        private void tbRuleValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13) this.Close();
        }
    }
}
