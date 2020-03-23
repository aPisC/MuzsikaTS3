using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MuzsikaTS_Rendező
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
        
        static public byte Search(this string SearchIn, string SearchThis)
        {
            if (SearchThis == null) return 0;
            if (SearchIn == null) { if (SearchThis.Trim().ToLower() == "'null'")return 1; else return 0; }
            if (SearchIn.Length < SearchThis.Length) return 0;
            for (int i = 0; i < 1 + SearchIn.Length - SearchThis.Length; i++)
            {
                if (SearchThis == SearchIn.Substring(i, SearchThis.Length)) return 3;
                if (SearchThis.Trim().ToLower() == SearchIn.Substring(i, SearchThis.Length).Trim().ToLower()) return 2;
            }
            return 0;
        }

        public static string ToStringLine<T>(this IEnumerable<T> list, string segmenter = " ")
        {
            string Line = "";
            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    Line += item.ToString() + segmenter;
                }
                Line = Line.Substring(0, Line.Length - segmenter.Length);
            }
            return Line;
        }

        public static bool Equals2(this string line1, string line2)
        {
            line2 = "^"+line2.Replace(".", @"\.").Replace("*", ".*").Replace("?", ".");
            bool ret = System.Text.RegularExpressions.Regex.IsMatch(line1, line2, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return ret;
        }

        public static string ToStringNull(this string s1)
        {
            if (s1 == "" || s1 == null) return "!NULL!";
            return s1;
        }

        public static void RemoveAll(this ListBox.ObjectCollection coll, Func<object, bool>removeIt )
        {
            HashSet<object> RemovableItems = new HashSet<object>();
            foreach (object item in coll)
            {
                if (removeIt(item)) RemovableItems.Add(item);
            }
            foreach (object item in RemovableItems)
            {
                coll.Remove(item);
            }
        }

        public static IEnumerable<T> ToIEnumerable<T>(this ListBox.SelectedObjectCollection coll)
        {
            List<T> ret = new List<T>();
            foreach (object item in coll)
            {
                yield return (T)item;
            }
        }

        public static List<T> Clone<T>(this List<T> list)
        { return list.OfType<T>().ToList(); }

        public static IEnumerable<MusicFile> AllowRules(this IEnumerable<MusicFile> list, IEnumerable<Rule> rules)
        {
            rules = rules.OrderByDescending(r => r.Mode.ToString());
            foreach (MusicFile item in list)
            {
                bool Forced = false;
                List<Rule> ForceRule = (from r in rules where r.Mode == Rule.RuleMode.Force && r.Enabled select r).ToList<Rule>();
                foreach (Rule rule in ForceRule)
                {
                    Forced |= rule.TestRule(item);
                    if (Forced) break;
                }
                if (Forced) { yield return item; continue; }
                List<Rule> DenyRule = (from r in rules where r.Mode == Rule.RuleMode.Deny && r.Enabled select r).ToList<Rule>();
                bool Denied = false;
                foreach (Rule rule in DenyRule)
                {
                    Denied |= rule.TestRule(item);
                    if (Denied) break;
                }
                if (Denied) { continue; }
                List<Rule> AllowRule = (from r in rules where r.Mode == Rule.RuleMode.Allow && r.Enabled select r).ToList<Rule>();
                bool Allowed = AllowRule.Count == 0;
                foreach (Rule rule in AllowRule)
                {
                    Allowed |= rule.TestRule(item);
                    if (Allowed) break;
                }
                if (Allowed) { yield return item; continue; }

            }
        }

        public static string ToUpperFirstLetter(this string s1)
        {
            if(s1.Length >0) return s1[0].ToString().ToUpper() + s1.Substring(1, s1.Length - 1);
            return "";
        }
    }

}