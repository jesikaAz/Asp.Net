using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OgameLikeTPClassLibrary.Entities
{
    public class Configuration
    {
        #region Private class variable
        private String key;
        private String data;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String Key
        {
            get { return key; }
            set { key = value; }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion
    }
}