using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using RuleEngine.Parsers;

namespace RuleEngine
{
    public static class REngine
    {
        private static RConfig config;

        static REngine()
        {
            LoadSettings();
        }

        private static void LoadSettings()
        {
            config = new RConfig();
            config.ThrowExceptionIfNotfoundRule = false;

            if (ConfigurationManager.AppSettings["REngine.ThrowExceptionIfNotfoundRule"] != null)
                config.ThrowExceptionIfNotfoundRule = Convert.ToString(ConfigurationManager.AppSettings["REngine.ThrowExceptionIfNotfoundRule"]) == "1";

            if (ConfigurationManager.AppSettings["REngine.RulefilesPath"] == null)
                throw new Exception("不存在REngine.RulefilesPath的key，在AppSetting中");

            config.RulefilesPath = ConfigurationManager.AppSettings["REngine.RulefilesPath"];
            config.RulefilesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config.RulefilesPath);

            if (!System.IO.Directory.Exists(config.RulefilesPath))
                throw new Exception("规则文件目录不存在");

            LoadRules();
        }

        private static void LoadRules()
        {
            var files=System.IO.Directory.GetFiles(config.RulefilesPath, "*.rule");
            if (files == null || files.Length == 0)
                throw new Exception("rule文件不存在");

            StringBuilder text = new StringBuilder();
            files.ToList().ForEach(file => {
                var fileText = System.IO.File.ReadAllText(file);
                text.AppendLine(fileText);
            });

            List<RuleRegion> regions=RegionParser.ParseRegions(text.ToString());
            if (regions == null || regions.Count == 0)
                throw new Exception("region不存在");

            regions.ForEach(region => {
                var rules = RuleParser.ParseRules(region.RegionContent);

                if (regions == null || regions.Count == 0)
                    throw new Exception(string.Format("region '{0}' 无法找到rule", region.RegionName));

                rules.ForEach(rule => {
                    rule.RegionName = region.RegionName;
                });

                rules.ForEach(rule =>{
                    var key=string.Format("{0}.{1}", rule.RegionName, rule.RuleName);
                    config.RuleDefinations[key] = rule;
                });
            });
        }

        private static string DefaultRuleName = "default";
        private static string LocateRuleContent(string ruleRegionId, string ruleId)
        {
            var key = string.Format("{0}.{1}", ruleRegionId, ruleId);
            if(config.RuleDefinations.ContainsKey(key))
                return config.RuleDefinations[key].RuleContent;

            if (config.ThrowExceptionIfNotfoundRule)
                throw new Exception("没有找到"+key);

            key = string.Format("{0}.{1}", ruleRegionId, DefaultRuleName);
            if (config.RuleDefinations.ContainsKey(key))
                return config.RuleDefinations[key].RuleContent;

            throw new Exception("没有找到" + key);
        }

        public static ParameterInfo CreateParameter(string name, object value)
        {
            ParameterInfo info = new ParameterInfo();
            info.ParameterName = name;
            info.ParameterValue = value;
            return info;
        }

        public static float InvokeAsFloat(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Float(ruleCode, parameters);
        }
        public static float InvokeAsFloat(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Float(ruleCode, parameters);
        }

        public static float InvokeAsInt(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Int(ruleCode, parameters);
        }
        public static float InvokeAsInt(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Int(ruleCode, parameters);
        }

        public static decimal InvokeAsDecimal(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Decimal(ruleCode, parameters);
        }
        public static decimal InvokeAsDecimal(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Decimal(ruleCode, parameters);
        }

        public static Single InvokeAsSingle(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Single(ruleCode, parameters);
        }
        public static Single InvokeAsSingle(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Single(ruleCode, parameters);
        }

        public static double InvokeAsDouble(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Double(ruleCode, parameters);
        }
        public static double InvokeAsDouble(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Double(ruleCode, parameters);
        }
        
        public static bool InvokeAsBool(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_Bool(ruleCode, parameters);
        }
        public static bool InvokeAsBool(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_Bool(ruleCode, parameters);
        }
        
        public static string InvokeAsString(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            return Engine.GetResult_String(ruleCode, parameters);
        }
        public static string InvokeAsString(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            return Engine.GetResult_String(ruleCode, parameters);
        }
        
        public static void InvokeAsVoid(string ruleRegionId, string ruleId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, ruleId);
            Engine.GetResult_Void(ruleCode, parameters);
        }
        public static void InvokeAsVoid(string ruleRegionId, params ParameterInfo[] parameters)
        {
            var ruleCode = LocateRuleContent(ruleRegionId, DefaultRuleName);
            Engine.GetResult_Void(ruleCode, parameters);
        }
    }
}
