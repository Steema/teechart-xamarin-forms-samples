using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms.Internals;

namespace XamControls.Utils
{
    public class FileController
    {

        private StreamReader sReader;
        private StreamWriter sWriter;
        private string fileName;

        public FileController()
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            fileName = Path.Combine(path, "options.txt");

        }

        // Permite leer el theme actual
        public string LeerThemeActual()
        {

            string themeValue = "";

            try {

                sReader = new StreamReader(fileName, false);
                themeValue = InternalReadThemeValue();

            }
            catch(Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                sReader.Close();

            }

            return themeValue;

        }

        // Internal -- Lee el valor del tema
        private string InternalReadThemeValue()
        {

            bool trobat = false;
            string line;
            string value = "";

            try
            {

                line = sReader.ReadLine();
                while (!trobat && line != null)
                {

                    if (line.Contains("theme:")) { trobat = true; }
                    else { line = sReader.ReadLine(); }

                }

                value = GetValue(line, "theme:");

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }

            }

            return value;

        }

        // Actualiza el valor del theme en el fichero
        public void UpdateThemeActual(string newValue)
        {

            bool trobatRead = false;
            string line;
            ArrayList lastContent = new ArrayList();
            int numLine = 0;

            try
            {

                sReader = new StreamReader(fileName, false);

                line = sReader.ReadLine();

                while (line != null)
                {

                    lastContent.Add(line);
                    if (!trobatRead && !line.Contains("theme:")) numLine++;
                    else { trobatRead = true; }
                    line = sReader.ReadLine();

                }

                sReader.Close();

                sWriter = new StreamWriter(fileName, false);

                lastContent[numLine] = GetTitleConfig((string)lastContent[numLine], "theme:")+newValue;

                for(int i = 0; i < lastContent.Count; i++)
                {

                    sWriter.WriteLine(lastContent[i]);

                }

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }
                if (sWriter != null) { sWriter.Close(); }

            }

        }

        // ----------------------------------------------------------------------------

        /// <summary>
        /// ReadValues NO ACABADO
        /// </summary>
        /// <returns></returns>

        public bool ReadValues(string titleValue)
        {

            return BooleanReadValues(titleValue);

        }

        // Devuelve el valor de la opción zoom {{{ READVALUES }}}
        public bool BooleanReadValues(string titleValue)
        {

            string zoomValue = "";
            bool isZoomEnabled = false;

            try
            {

                sReader = new StreamReader(fileName, false);
                zoomValue = InternalBoolReadValues(titleValue);

                isZoomEnabled = Convert.ToBoolean(zoomValue);

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                sReader.Close();

            }

            return isZoomEnabled;

        }

        // Internal -- Lee el valor del zoom {{{ READVALUES }}}
        private string InternalBoolReadValues(string titleValue)
        {

            bool trobat = false;
            string line;
            string value = "";

            try
            {

                line = sReader.ReadLine();
                while (!trobat && line != null)
                {

                    if (line.Contains(titleValue)) { trobat = true; }
                    else { line = sReader.ReadLine(); }

                }

                value = GetValue(line, titleValue);

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }

            }

            return value;

        }

        public void UpdateBooleanValues(string newValue, string titleValue)
        {

            bool trobatRead = false;
            string line;
            ArrayList lastContent = new ArrayList();
            int numLine = 0;

            try
            {

                sReader = new StreamReader(fileName, false);

                line = sReader.ReadLine();

                while (line != null)
                {

                    lastContent.Add(line);
                    if (!trobatRead && !line.Contains(titleValue)) numLine++;
                    else { trobatRead = true; }
                    line = sReader.ReadLine();

                }

                sReader.Close();

                sWriter = new StreamWriter(fileName, false);

                lastContent[numLine] = GetTitleConfig((string)lastContent[numLine], titleValue) + newValue;

                for (int i = 0; i < lastContent.Count; i++)
                {

                    sWriter.WriteLine(lastContent[i]);

                }

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }
                if (sWriter != null) { sWriter.Close(); }

            }

        }

        // ------------------------------------------------------------------


        // Devuelve el valor de la opción zoom
        public bool LeerZoomActual()
        {

            string zoomValue = "";
            bool isZoomEnabled = false;

            try
            {

                sReader = new StreamReader(fileName, false);
                zoomValue = InternalReadZoomValue();

                isZoomEnabled = Convert.ToBoolean(zoomValue);

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {
                if (sReader != null)
                {
                    sReader.Close();
                }

            }

            return isZoomEnabled;

        }

        // Internal -- Lee el valor del zoom
        private string InternalReadZoomValue()
        {

            bool trobat = false;
            string line;
            string value = "";

            try
            {

                line = sReader.ReadLine();
                while (!trobat && line != null)
                {

                    if (line.Contains("zoom:")) { trobat = true; }
                    else { line = sReader.ReadLine(); }

                }

                value = GetValue(line, "zoom:");

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }

            }

            return value;

        }

        // Actualiza el valor del theme en el fichero
        public void UpdateZoomActual(string newValue)
        {

            bool trobatRead = false;
            string line;
            ArrayList lastContent = new ArrayList();
            int numLine = 0;

            try
            {

                sReader = new StreamReader(fileName, false);

                line = sReader.ReadLine();

                while (line != null)
                {

                    lastContent.Add(line);
                    if (!trobatRead && !line.Contains("zoom:")) numLine++;
                    else { trobatRead = true; }
                    line = sReader.ReadLine();

                }

                sReader.Close();

                sWriter = new StreamWriter(fileName, false);

                lastContent[numLine] = GetTitleConfig((string)lastContent[numLine], "zoom:") + newValue;

                for (int i = 0; i < lastContent.Count; i++)
                {

                    sWriter.WriteLine(lastContent[i]);

                }

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }
                if (sWriter != null) { sWriter.Close(); }

            }

        }

        // Permite leer el zoomtype actual
        public string LeerZoomTypeActual()
        {

            string themeValue = "";

            try
            {

                sReader = new StreamReader(fileName, false);
                themeValue = InternalReadZoomTypeValue();

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                sReader.Close();

            }

            return themeValue;

        }

        // Internal -- Lee el valor del zoomtype
        private string InternalReadZoomTypeValue()
        {

            bool trobat = false;
            string line;
            string value = "";

            try
            {

                line = sReader.ReadLine();
                while (!trobat && line != null)
                {

                    if (line.Contains("zoomtype:")) { trobat = true; }
                    else { line = sReader.ReadLine(); }

                }

                value = GetValue(line, "zoomtype:");

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }

            }

            return value;

        }

        // Actualiza el valor del zoomtype en el fichero
        public void UpdateZoomTypeActual(string newValue)
        {

            bool trobatRead = false;
            string line;
            ArrayList lastContent = new ArrayList();
            int numLine = 0;

            try
            {

                sReader = new StreamReader(fileName, false);

                line = sReader.ReadLine();

                while (line != null)
                {

                    lastContent.Add(line);
                    if (!trobatRead && !line.Contains("zoomtype:")) numLine++;
                    else { trobatRead = true; }
                    line = sReader.ReadLine();

                }

                sReader.Close();

                sWriter = new StreamWriter(fileName, false);

                lastContent[numLine] = GetTitleConfig((string)lastContent[numLine], "zoomtype:") + newValue;

                for (int i = 0; i < lastContent.Count; i++)
                {

                    sWriter.WriteLine(lastContent[i]);

                }

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if (sReader != null) { sReader.Close(); }
                if (sWriter != null) { sWriter.Close(); }

            }

        }

        // Determina si tienes los archivos de la app creados (si es la primera vez que entras no los tienes)
        public void AppFilesCreated()
        {

            if (!File.Exists(fileName)) { CreateBasicFiles(); }

        }

        // Crea los archivos principales de la "app" si es
        public void CreateBasicFiles()
        {

            try
            {

                sWriter = new StreamWriter(fileName, false);

                sWriter.WriteLine("theme:None");
                sWriter.WriteLine("zoom:false");
                sWriter.WriteLine("panning:false");
                //sWriter.WriteLine("zoomtype:InChart");

            }
            catch (Exception e) { Log.Warning(e.Source, e.StackTrace); }
            finally
            {

                if(sWriter != null) { sWriter.Close(); }

            }


        }

        // Obtienes el valor del apartado
        private string GetValue(string line, string key)
        {

            string value;

            value = line.Remove(0, key.Length);

            return value;

        }

        // Obtienes el nombre del apartado
        private string GetTitleConfig(string line, string key)
        {

            string titleConfig;

            titleConfig = line.Remove(key.Length);

            return titleConfig;

        }

        // Elimina el archivo
        private void RemoveFile()
        {

            File.Delete(fileName);

        }

    }
}
