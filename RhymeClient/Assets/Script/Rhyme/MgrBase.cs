using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Rhyme.Common
{
	public abstract class MgrBase<T> : IDisposable
	{
		private bool _disposed;

		protected Dictionary<string, T> _data;
		protected String _fileName;
		protected string _filePath;
		protected bool _isInitialized;

		protected MgrBase()
		{
			_isInitialized = false;
		}

		public virtual void Dispose()
		{
			try
			{
				if (!_disposed)
				{
					if (_data == null)
						return;

					_data.Clear();
					_data = null;

					_disposed = true;
				}
			}
			catch (Exception ex)
			{
				//Logger.Log(LogInfo.Warn, "MgrBase::Dispose Unhandled Exception. FileName = {0}. Exception={1}", _fileName, ex.ToString());
			}
		}

		public virtual void Init(string path, string fileName)
		{
			_isInitialized = true;
			_filePath = path;
			_fileName = fileName;
			_data = new Dictionary<string, T>();
			LoadFile(_filePath + _fileName);
		}

		public virtual void Reload()
		{
			Debug.Assert(_isInitialized);

			_data.Clear();
			LoadFile(_fileName);
		}

		private void LoadFile(string fileName)
		{
			String xmlAsString = null;
			var xmlDoc = new XmlDocument();
			xmlDoc.Load(fileName);

			using (var stringWriter = new StringWriter())
			using (XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter))
			{
				xmlDoc.WriteTo(xmlTextWriter);
				xmlTextWriter.Flush();
				xmlAsString = stringWriter.ToString();
			}

			try
			{
				XDocument doc = XDocument.Parse(xmlAsString);
				FillData(doc);
			}
			catch (XmlException e)
			{
				Debug.Assert(false, e.Message);
			}
		}

		protected abstract void FillData(XDocument doc);
	}
}