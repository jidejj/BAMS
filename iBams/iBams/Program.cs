using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Xpo.DB;
using PBMSModel.PBMS;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace iBams
{
    static class Program
    {
        public static string ID_Login;
        public static string FullName;
        public static string IsVendor;
        public static string FirstName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);
            PBMSModel.Ibs_Security.ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Metropolis");
            Application.Run(new Login());
        }

        public static String Sec_Key()
        {
            return "IBS_Simplex_System_Encryption_Text";
        }

        public static String EncryptString(String inputtext)
        {
            String passwordKey = Sec_Key();

            if (inputtext == "")
                return inputtext;

            //We are now going to create an instance of theRihndael class. 
            RijndaelManaged rijndaelcipher = new RijndaelManaged();
            //First we need to turn the input strings into a byte array.
            Byte[] plaintext = System.Text.Encoding.Unicode.GetBytes(inputtext);
            //We are using salt to make it harder to guess our key using a dictionary attack.
            Byte[] salt = Encoding.ASCII.GetBytes(passwordKey);
            //The (Secret Key) will be generated from the specified password and salt.
            Rfc2898DeriveBytes secretkey = new Rfc2898DeriveBytes(passwordKey, salt);
            //Create a encryptor from the existing SecretKey bytes.
            //We use 32 bytes for the secret key.The default Rijndael key length is 256 bit = 32 bytes)
            //then 16 bytes for the IV (initialization vector).The default Rijndael IV length is 128 bit = 16 bytes)
            ICryptoTransform encryptor = rijndaelcipher.CreateEncryptor(secretkey.GetBytes(32), secretkey.GetBytes(16));
            //Create a MemoryStream that is going to hold the encrypted bytes
            MemoryStream memstream = new MemoryStream();
            //Create a CryptoStream through which we are going to be processing our data.
            //CryptoStreamMode.Write means that we are going to be writing data
            //to the stream and the output will be written in the MemoryStream
            //we have provided. (always use write mode for encryption)
            CryptoStream mycryptostream = new CryptoStream(memstream, encryptor, CryptoStreamMode.Write);
            //Start the encryption process.
            mycryptostream.Write(plaintext, 0, plaintext.Length);
            //Finish encrypting.
            mycryptostream.FlushFinalBlock();
            //Convert our encrypted data from a memoryStream into a byte array.
            Byte[] cipherbytes = memstream.ToArray();
            //Close both streams.
            memstream.Close();
            mycryptostream.Close();
            //Convert encrypted data into a base64-encoded string.
            //A common mistake would be to use an Encoding class for that.
            //It does not work, because not all byte values can be
            //represented by characters. We are going to be using Base64 encoding
            //That is designed exactly for what we are trying to do.
            String encrypteddata = Convert.ToBase64String(cipherbytes);
            //Return encrypted string.
            return encrypteddata;
        }

        public static String DecryptString(String inputtext)
        {

            String password = Sec_Key();

            if (inputtext == "")
                return inputtext;

            RijndaelManaged rijndaelcipher = new RijndaelManaged();
            Byte[] encrypteddata = Convert.FromBase64String(inputtext);
            Byte[] salt = Encoding.ASCII.GetBytes(password);
            Rfc2898DeriveBytes secretkey = new Rfc2898DeriveBytes(password, salt);
            // Create a decryptor from the existing SecretKey bytes.
            ICryptoTransform decryptor = rijndaelcipher.CreateDecryptor(secretkey.GetBytes(32), secretkey.GetBytes(16));
            MemoryStream memStream = new MemoryStream(encrypteddata);
            // Create a CryptoStream. (always use Read mode for decryption).
            CryptoStream mycryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read);
            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold EncryptedData;
            // DecryptedData is never longer than EncryptedData.
            Byte[] plaintext = new Byte[encrypteddata.Length];
            // Start decrypting.
            int decryptedcount = mycryptoStream.Read(plaintext, 0, plaintext.Length);
            memStream.Close();
            mycryptoStream.Close();
            // Convert decrypted data into a string.
            String DecryptedData = Encoding.Unicode.GetString(plaintext, 0, decryptedcount);
            // Return decrypted string.  
            return DecryptedData;
        }
    }
}
