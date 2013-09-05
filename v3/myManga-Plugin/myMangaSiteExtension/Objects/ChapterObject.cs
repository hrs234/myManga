﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Core.IO;
using myMangaSiteExtension.Collections;

namespace myMangaSiteExtension.Objects
{
    [Serializable, XmlRoot, DebuggerStepThrough]
    public class ChapterObject : SerializableObject, INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region NotifyPropertyChange
        public event PropertyChangingEventHandler PropertyChanging;
        protected void OnPropertyChanging([CallerMemberName] String caller = "")
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(caller));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String caller = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Protected
        [NonSerialized, XmlIgnore, EditorBrowsable(EditorBrowsableState.Never)]
        protected String name;

        [NonSerialized, XmlIgnore, EditorBrowsable(EditorBrowsableState.Never)]
        protected List<Core.IO.KeyValuePair<String, String>> locations;

        [NonSerialized, XmlIgnore, EditorBrowsable(EditorBrowsableState.Never)]
        protected PageObjectCollection pages;
        #endregion

        #region Public
        [NonSerialized, XmlIgnore]
        public readonly MangaObject ParentMangaObject;

        [XmlAttribute]
        public String Name
        {
            get { return name; }
            set
            {
                OnPropertyChanging();
                name = value;
                OnPropertyChanged();
            }
        }

        [XmlArray, XmlArrayItem]
        public List<Core.IO.KeyValuePair<String, String>> Locations
        {
            get
            {
                if (locations == null)
                    locations = new List<Core.IO.KeyValuePair<String, String>>();
                return locations;
            }
            set
            {
                OnPropertyChanging();
                locations = value;
                OnPropertyChanged();
            }
        }

        [XmlArray, XmlArrayItem]
        public PageObjectCollection Pages
        {
            get
            {
                if (pages == null)
                    pages = new PageObjectCollection();
                return pages;
            }
            set
            {
                OnPropertyChanging();
                pages = value;
                OnPropertyChanged();
            }
        }

        public ChapterObject() : base() { }
        public ChapterObject(MangaObject MangaObject) : this() { ParentMangaObject = MangaObject; }
        public ChapterObject(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}