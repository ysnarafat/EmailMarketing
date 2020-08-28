﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace EmailMarketing.EmailSendingWorkerService.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\DevSkillFInalProject\EmailMarketing\EmailMarketing.EmailSendingWorkerService\Templates\DemoEmailTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DemoEmailTemplate : DemoEmailTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n\t<link rel=\"stylesheet\" type=\"text/css\" href=\"ht" +
                    "tps://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n</h" +
                    "ead>\r\n<body style=\"background-color: #c9d6df;margin: 0px;\">\r\n\t<table border=\"0\" " +
                    "width=\"40%\" style=\"margin:auto;padding:30px;background-color: #F3F3F3;border:1px" +
                    " solid #3f72af;\">\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t\t<table border=\"0\" width=\"100%\">\r\n\t\t\t\t\t<t" +
                    "r>\r\n\t\t\t\t\t\t<td style=\"width:40px;\">\r\n\t\t\t\t\t\t\t<img src=\"https://img.icons8.com/colo" +
                    "r/48/000000/filled-sent.png\"/>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<h1 style=\"font-" +
                    "family: system-ui;font-size:25px;\">Bulk Email System</h1>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<t" +
                    "d>\r\n\t\t\t\t\t\t\t<p style=\"font-family: system-ui;text-align: right;font-size:13px;\"><" +
                    "a href=\"https://nicesnippets.com/\" target=\"_blank\" style=\"text-decoration: none;" +
                    "\">View In Website</a></p>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t</table>\r\n\t\t\t</td>\r\n\t\t</" +
                    "tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t\t<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" styl" +
                    "e=\"text-align:center;width:100%;background-color: #fff;\">\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td " +
                    "style=\"background-color:#3f72af;height:80px;font-size:50px;color:#fff;\"><img sty" +
                    "le=\"margin-top:10px;\" src=\"https://img.icons8.com/color/48/000000/secured-letter" +
                    ".png\"/></i></td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<h2 style=\"font-fami" +
                    "ly: system-ui;padding-top:25px;font-size:20px;\">Campaign Sent Confirmation</h2>\r" +
                    "\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<p style=\"padding:0px 10" +
                    "0px;font-family:system-ui;text-align:left;font-weight:bold;font-size:15px;\">\r\n\t\t" +
                    "\t\t\t\t\t\tDear ");
            
            #line 44 "D:\DevSkillFInalProject\EmailMarketing\EmailMarketing.EmailSendingWorkerService\Templates\DemoEmailTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(@",
							</p>
							<p style=""padding:0px 100px 10px;font-family: system-ui;text-align:left;font-size:13px;"">
								Your Campaign has been sent successfully. Below is the report of the Campaign sent information.
							</p>
						</td>
					</tr>
					<tr>
						<td>
              <table style=""text-align:center;background-color: #fff;margin:auto;"">
                <tr>
                  <td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;"">
                      Success Email Count
                    </p>
                  </td>
									<td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;padding: 0 10px;"">
                      :
                    </p>
                  </td>
                  <td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;"">
                      ");
            
            #line 67 "D:\DevSkillFInalProject\EmailMarketing\EmailMarketing.EmailSendingWorkerService\Templates\DemoEmailTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TotalCount));
            
            #line default
            #line hidden
            this.Write(@"
                    </p>
                  </td>
                </tr>
								<tr>
                  <td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;margin-top:0;"">
                      Failed Email Count
                    </p>
                  </td>
									<td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;padding: 0 10px;margin-top:0;"">
                      :
                    </p>
                  </td>
                  <td>
                    <p style=""font-family: system-ui;text-align:left;font-size:13px;margin-top:0;"">
                      ");
            
            #line 84 "D:\DevSkillFInalProject\EmailMarketing\EmailMarketing.EmailSendingWorkerService\Templates\DemoEmailTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TotalFailed));
            
            #line default
            #line hidden
            this.Write("\r\n                    </p>\r\n                  </td>\r\n                </tr>\r\n     " +
                    "         </table>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<p sty" +
                    "le=\"padding:10px 100px 0px;font-family: system-ui;text-align:left;font-size:13px" +
                    ";\">\r\n\t\t\t\t\t\t\t  All the best,<br /> Bulk Email System Team\r\n\t\t\t\t\t\t\t</p>\r\n\t\t\t\t\t\t</t" +
                    "d>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t</table>\r\n\t\t\t</td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t\t<table bor" +
                    "der=\"0\" width=\"100%\" style=\"border-radius: 5px;text-align: center;margin-top:10p" +
                    "x;\">\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<h3 style=\"margin-top:10px;font-family: syst" +
                    "em-ui;font-size:17px; \">Stay in touch</h3>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t\t<tr>\r\n" +
                    "\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<div style=\"margin-top:0px;\">\r\n\t\t\t\t\t\t\t\t<a href=\"#\" style=\"tex" +
                    "t-decoration: none;\"><img src=\"https://img.icons8.com/color/35/000000/twitter-ci" +
                    "rcled.png\"/></a>\r\n\t\t\t\t\t\t\t\t<a href=\"#\" style=\"text-decoration: none;\"><img src=\"h" +
                    "ttps://img.icons8.com/fluent/35/000000/facebook-new.png\"/></a>\r\n\t\t\t\t\t\t\t\t<a href=" +
                    "\"#\" style=\"text-decoration: none;\"><img src=\"https://img.icons8.com/color/35/000" +
                    "000/circled-envelope.png\"/></a>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t\t<t" +
                    "r>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<div style=\"margin-top: 10px;\">\r\n\t\t\t\t\t\t\t\t<span style=\"fon" +
                    "t-size:12px;font-family: system-ui;font-size:11px;\">Bulk Email System</span><br>" +
                    "\r\n\t\t\t\t\t\t\t\t<span style=\"font-size:12px;font-family: system-ui;font-size:11px;\">Co" +
                    "pyright © 2020 DevSkill Team A</span>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t" +
                    "\t\t\t</table>\r\n\t\t\t</td>\r\n\t\t</tr>\r\n\t</table>\r\n</body>\r\n</html>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class DemoEmailTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
