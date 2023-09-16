//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Object that is responsible for writing out the string representation
    /// of objects to the log file. Works in a way very similar to LINQPad's Dump()
    /// method.
    /// </summary>
    public class ObjectDumper
    {
        /// <summary>
        /// Integer specifying the depth (inheritance levels) to which to dump
        /// object data.
        /// </summary>
        /// <remarks> Must be zero or greater. </remarks>
        private readonly int _depth;

        /// <summary> Integer specifying the current position in the output stream. </summary>
        private int _currentStreamPosition;

        /// <summary> Integer specifying the indentation level of the logged data. </summary>
        /// <remarks> Must be 1 or greater. </remarks>
        private int _indentLevel;

        /// <summary>
        /// Reference to a <see cref="T:System.IO.TextWriter" /> to which to send
        /// the logged data.
        /// </summary>
        private TextWriter _writer;

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ObjectDumper" /> and returns a reference to it.
        /// </summary>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth (in terms
        /// of inheritance levels) to which to dump object data.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="depth" /> parameter is not zero or greater.
        /// </exception>
        private ObjectDumper(int depth)
        {
            if (depth < 0)
                throw new ArgumentOutOfRangeException(nameof(depth));

            _depth = depth;
        }

        /// <summary> Occurs when text is written to an output stream. </summary>
        public static event TextWrittenEventHandler TextWritten;

        /// <summary>
        /// Writes an object, a reference to which is specified by the
        /// <paramref name="element" /> parameter, to the log, to the number of inheritance
        /// levels specified by <paramref name="depth" />.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to an instance of an object that
        /// should be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer specifying how far up the inheritance
        /// chain to dump. Default is zero. Must be zero or greater.
        /// </param>
        /// <remarks>
        /// By default, this overload of the method sends the dump output to the
        /// <see cref="T:System.Console.Out" /> stream.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="element" />, is passed a <see langword="null" />
        /// value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="depth" /> parameter is not zero or greater.
        /// </exception>
        public static void Write(object element, int depth = 0)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(nameof(depth));
            Write(element, depth, Console.Out);
        }

        /// <summary>
        /// Writes an object, a reference to which is specified by the
        /// <paramref name="element" /> parameter, to the log, to the number of inheritance
        /// levels specified by <paramref name="depth" />, and outputs it to the
        /// <see cref="T:System.IO.TextWriter" /> instance referred to by the
        /// <paramref name="log" /> parameter.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to an instance of an object that
        /// should be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer specifying how far up the inheritance
        /// chain to dump. Default is zero. Must be zero or greater.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.IO.TextWriter" /> to which output should be sent.
        /// </param>
        /// <remarks>
        /// By default, this overload of the method sends the dump output to the
        /// <see cref="T:System.Console.Out" /> stream.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if either of the
        /// required parameters, <paramref name="element" /> or <paramref name="log" />,
        /// are passed a <see langword="null" /> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="depth" /> parameter is not zero or greater.
        /// </exception>
        public static void Write(object element, int depth, TextWriter log)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(nameof(depth));
            if (log == null) throw new ArgumentNullException(nameof(log));

            var dumper = new ObjectDumper(depth) { _writer = log };
            dumper.WriteObject(null, element);
        }

        /// <summary>
        /// Writes an object, a reference to which is specified by the
        /// <paramref name="element" /> parameter, to the log, to the number of inheritance
        /// levels specified by <paramref name="depth" />, followed by a newline character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to an instance of an object that
        /// should be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer specifying how far up the inheritance
        /// chain to dump. Default is zero. Must be zero or greater.
        /// </param>
        /// <remarks>
        /// By default, this overload of the method sends the dump output to the
        /// <see cref="T:System.Console.Out" /> stream.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="element" />, is passed a <see langword="null" />
        /// value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="depth" /> parameter is not zero or greater.
        /// </exception>
        public static void WriteLine(object element, int depth = 0)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(nameof(depth));
            WriteLine(element, depth, Console.Out);
        }

        /// <summary>
        /// Writes an object, a reference to which is specified by the
        /// <paramref name="element" /> parameter, to the log, to the number of inheritance
        /// levels specified by <paramref name="depth" />, and outputs it to the
        /// <see cref="T:System.IO.TextWriter" /> instance referred to by the
        /// <paramref name="log" /> parameter, followed by a newline character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to an instance of an object that
        /// should be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer specifying how far up the inheritance
        /// chain to dump. Default is zero. Must be zero or greater.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.IO.TextWriter" /> to which output should be sent.
        /// </param>
        /// <remarks>
        /// By default, this overload of the method sends the dump output to the
        /// <see cref="T:System.Console.Out" /> stream.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if either of the
        /// required parameters, <paramref name="element" /> or <paramref name="log" />,
        /// are passed a <see langword="null" /> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="depth" /> parameter is not zero or greater.
        /// </exception>
        public static void WriteLine(object element, int depth, TextWriter log)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(nameof(depth));
            if (log == null) throw new ArgumentNullException(nameof(log));
            var dumper = new ObjectDumper(depth) { _writer = log };
            dumper.WriteObjectToLines(null, element);
        }

        /// <summary>
        /// Raises the <see cref="E:xyLOGIX.Core.Debug.ObjectDumper.TextWritten" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:xyLOGIX.Core.Debug.Events.TextWrittenEventArgs" />
        /// that contains the event data.
        /// </param>
        protected static void OnTextWritten(TextWrittenEventArgs e)
            => TextWritten?.Invoke(e);

        /// <summary>
        /// Writes the content in the string, <paramref name="s" />, to the
        /// <see cref="T:System.IO.TextWriter" /> wrapped by this object.
        /// </summary>
        /// <param name="s"> (Required.) String containing the content to be written. </param>
        /// <remarks> This method does nothing if <paramref name="s" /> is a blank string. </remarks>
        private void Write(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return;

            _writer.Write(s);
            OnTextWritten(new TextWrittenEventArgs(s));
            _currentStreamPosition += s.Length;
        }

        /// <summary>
        /// Writes an indent -- a 4 space tab -- to the
        /// <see cref="T:System.IO.TextWriter" /> that is wrapped by this object in the
        /// <see cref="F:xyLOGIX.Core.Debug.ObjectDumper._writer" /> field at the indent level
        /// given by the value of the
        /// <see cref="F:xyLOGIX.Core.Debug.ObjectDumper._indentLevel" /> field.
        /// </summary>
        private void WriteIndent()
        {
            if (_indentLevel < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(_indentLevel),
                    "Value of the indent level must be zero or greater."
                );

            for (var i = 0; i < _indentLevel; i++)
            {
                _writer.Write("   ");
                OnTextWritten(new TextWrittenEventArgs("    "));
            }
        }

        /// <summary>
        /// Outputs a blank line to the <see cref="T:System.IO.TextWriter" />
        /// that is wrapped by this object.
        /// </summary>
        /// <remarks>
        /// This method does nothing if the
        /// <see cref="F:xyLOGIX.Core.Debug.ObjectDumper._writer" /> field is a
        /// <see langword="null" /> reference.
        /// </remarks>
        private void WriteLine()
        {
            if (_writer == null)
                return;

            _writer.WriteLine();
            OnTextWritten(new TextWrittenEventArgs("\r\n"));
            _currentStreamPosition = 0;
        }

        /// <summary>
        /// Workhorse method that actually does the job of writing the specified
        /// <paramref name="element" /> object to the output stream, with the specified
        /// <paramref name="prefix" />.
        /// </summary>
        /// <param name="prefix">
        /// (Optional.) String containing the prefix to be used. May
        /// be blank or <see langword="null" />.
        /// </param>
        /// <param name="element">
        /// (Required.) Reference to the instance of the object to
        /// be dumped to the output stream.
        /// </param>
        private void WriteObject(string prefix, object element)
        {
            if (element == null || element is ValueType || element is string)
            {
                WriteIndent();
                Write(prefix);
                WriteValue(element);
                WriteLine();
            }
            else
            {
                if (element is IEnumerable enumerableElement)
                {
                    foreach (var item in enumerableElement)
                        if (item is IEnumerable && !(item is string))
                        {
                            WriteIndent();
                            Write(prefix);
                            Write("...");
                            WriteLine();
                            if (_indentLevel >= _depth) continue;
                            _indentLevel++;
                            WriteObject(prefix, item);
                            _indentLevel--;
                        }
                        else
                        {
                            WriteObject(prefix, item);
                        }
                }
                else
                {
                    var members = element.GetType()
                                         .GetMembers(
                                             BindingFlags.Public |
                                             BindingFlags.Instance
                                         );
                    if (members == null || !members.Any())
                        return;

                    WriteIndent();
                    Write(prefix);
                    var propWritten = false;
                    foreach (var m in members)
                    {
                        var f = m as FieldInfo;
                        var p = m as PropertyInfo;
                        if (f == null && p == null) continue;
                        if (propWritten)
                            WriteTab();
                        else
                            propWritten = true;
                        Write(m.Name);
                        Write("=");
                        var t = f != null ? f.FieldType : p.PropertyType;
                        if (t.IsValueType || t == typeof(string))
                            WriteValue(
                                f != null
                                    ? f.GetValue(element)
                                    : p.GetValue(element, null)
                            );
                        else
                            Write(
                                typeof(IEnumerable).IsAssignableFrom(t)
                                    ? "..."
                                    : "{ }"
                            );
                    }

                    if (propWritten) WriteLine();
                    if (_indentLevel >= _depth) return;

                    foreach (var m in members)
                    {
                        var f = m as FieldInfo;
                        var p = m as PropertyInfo;
                        if (f == null && p == null) continue;
                        var t = f != null ? f.FieldType : p.PropertyType;
                        if (t.IsValueType || t == typeof(string)) continue;
                        var value = f != null
                            ? f.GetValue(element)
                            : p.GetValue(element, null);
                        if (value == null) continue;
                        _indentLevel++;
                        WriteObject(m.Name + ": ", value);
                        _indentLevel--;
                    }
                }
            }
        }

        /// <summary>
        /// Workhorse method that actually does the job of writing the specified
        /// <paramref name="element" /> object to the output stream, with the specified
        /// <paramref name="prefix" />, with a newline character inserted after each line
        /// of text.
        /// </summary>
        /// <param name="prefix">
        /// (Optional.) String containing the prefix to be used. May
        /// be blank or <see langword="null" />.
        /// </param>
        /// <param name="element">
        /// (Required.) Reference to the instance of the object to
        /// be dumped to the output stream.
        /// </param>
        private void WriteObjectToLines(string prefix, object element)
        {
            if (element == null || element is ValueType || element is string)
            {
                WriteLine();
                Write(prefix);
                WriteValue(element);
                WriteLine();
            }
            else
            {
                if (element is IEnumerable enumerableElement)
                {
                    foreach (var item in enumerableElement)
                        if (item is IEnumerable && !(item is string))
                        {
                            WriteLine();
                            Write(prefix);
                            Write("...");
                            WriteLine();
                            if (_indentLevel >= _depth) continue;
                            _indentLevel++;
                            WriteObjectToLines(prefix, item);
                            _indentLevel--;
                        }
                        else
                        {
                            WriteObjectToLines(prefix, item);
                        }
                }
                else
                {
                    var members = element.GetType()
                                         .GetMembers(
                                             BindingFlags.Public |
                                             BindingFlags.Instance
                                         );
                    if (members == null || !members.Any()) return;

                    WriteLine();
                    Write(prefix);
                    var propWritten = false;
                    foreach (var m in members)
                    {
                        var f = m as FieldInfo;
                        var p = m as PropertyInfo;
                        if (f == null && p == null) continue;
                        if (propWritten)
                            WriteLine();
                        else
                            propWritten = true;
                        Write(m.Name);
                        Write("=");
                        var t = f != null ? f.FieldType : p.PropertyType;
                        if (t.IsValueType || t == typeof(string))
                            WriteValue(
                                f != null
                                    ? f.GetValue(element)
                                    : p.GetValue(element, null)
                            );
                        else
                            Write(
                                typeof(IEnumerable).IsAssignableFrom(t)
                                    ? "..."
                                    : "{ }"
                            );
                    }

                    if (propWritten) WriteLine();
                    if (_indentLevel >= _depth) return;

                    foreach (var m in members)
                    {
                        var f = m as FieldInfo;
                        var p = m as PropertyInfo;
                        if (f == null && p == null) continue;
                        var t = f != null ? f.FieldType : p.PropertyType;
                        if (t.IsValueType || t == typeof(string)) continue;
                        var value = f != null
                            ? f.GetValue(element)
                            : p.GetValue(element, null);
                        if (value == null) continue;
                        _indentLevel++;
                        WriteObjectToLines(m.Name + ": ", value);
                        _indentLevel--;
                    }
                }
            }
        }

        /// <summary>
        /// Writes a 4-space tab at teh proper level of indent, depending on the
        /// current position within the stream.
        /// </summary>
        private void WriteTab()
        {
            Write("  ");
            while (_currentStreamPosition % 4 != 0) Write(" ");
        }

        /// <summary>
        /// Formats a value, specified by the reference to the instance of the
        /// object, <paramref name="o" />, in a nice way for output.
        /// </summary>
        /// <param name="o">
        /// (Required.) Reference to an instance of the object to be
        /// formatted and written to the output stream.
        /// </param>
        private void WriteValue(object o)
        {
            if (o == null)
                Write("null");
            else if (o is DateTime dateTime)
                Write(dateTime.ToShortDateString());
            else if (o is ValueType || o is string)
                Write(o.ToString());
            else if (o is IEnumerable)
                Write("...");
            else
                Write("{ }");
        }
    }
}