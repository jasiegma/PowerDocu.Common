
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PowerDocu.Common
{
    public static class DefaultChangeHelper
    {
        private static readonly string ControlDefaultsFile = AssemblyHelper.GetExecutablePath() + @"Resources\DefaultSettings\ControlDefaultSetting.json";
        private static readonly string AppDefaultsFile = AssemblyHelper.GetExecutablePath() + @"Resources\DefaultSettings\AppDefaultSetting.json";
        private static readonly string ScreenDefaultsFile = AssemblyHelper.GetExecutablePath() + @"Resources\DefaultSettings\ScreenDefaultSetting.json";
        private static List<Entity> entityDefaults;
        public static string DefaultValueIfUnknown = "";

        private static void InitializeEntityDefaults()
        {
            using StreamReader reader = new StreamReader(ControlDefaultsFile);
            string appJSON = reader.ReadToEnd();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, MaxDepth = 128 };
            var _jsonSerializer = JsonSerializer.Create(settings);
            entityDefaults = JsonConvert.DeserializeObject<List<Entity>>(appJSON, settings);
        }

        public static Entity GetEntityDefaults(string entity)
        {
            if (entityDefaults == null)
            {
                InitializeEntityDefaults();
            }
            return entityDefaults.Find(e => e.Template.Name == entity);
        }
    }

    public class Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string ServiceKind { get; set; }
        public Wadlmetadata WadlMetadata { get; set; }
        public string ApiId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public string ResourceKind { get; set; }
        public string RootPath { get; set; }
        public string OriginalSchema { get; set; }
        public string Data { get; set; }
        public string OriginalName { get; set; }
        public string[] OrderedColumnNames { get; set; }
        public string DatasetName { get; set; }
        public string TableName { get; set; }
        public Cdprevision CdpRevision { get; set; }
        public Dataentitymetadatajson DataEntityMetadataJson { get; set; }
        public Connecteddatasourceinfonamemapping ConnectedDataSourceInfoNameMapping { get; set; }
        public Template Template { get; set; }
        public float Index { get; set; }
        public float PublishOrderIndex { get; set; }
        public string VariantName { get; set; }
        public string LayoutName { get; set; }
        public string MetaDataIDKey { get; set; }
        public bool PersistMetaDataIDKey { get; set; }
        public bool IsFromScreenLayout { get; set; }
        public string StyleName { get; set; }
        public string Parent { get; set; }
        public bool IsDataControl { get; set; }
        public bool IsGroupControl { get; set; }
        public bool IsAutoGenerated { get; set; }
        public List<Rule> Rules { get; set; }
        public IList<object> ControlPropertyState { get; set; }
        public bool IsLocked { get; set; }
        public string ControlUniqueId { get; set; }
        public List<Entity> Children { get; set; }
        public Controlthisitemtype ControlThisItemType { get; set; }
        public string[] GroupedControlsKey { get; set; }
    }

    public class Cdprevision
    {
        public float RevisionNumber { get; set; }
        public string BaseUrl { get; set; }
        public DateTime LastChangedTimeString { get; set; }
    }

    public class Wadlmetadata
    {
        public string WadlXml { get; set; }
        public string SwaggerJson { get; set; }
    }

    public class Template
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public bool IsCustomGroupControlTemplate { get; set; }
        public string CustomGroupControlTemplateName { get; set; }
        public OverridableProperties OverridableProperties { get; set; }
    }

    public class OverridableProperties
    {
    }

    public class Controlthisitemtype
    {
        public string Version { get; set; }
        public Type Type { get; set; }
    }

    public class Dataentitymetadatajson
    {
        public string _0f2c1402395448c3966c29af3ce8abf8 { get; set; }
        public string cd4c06dfc1854e528710f3cee2ae6f2e { get; set; }
        public string _77fc8f452de84e8fa695e8dc90844bb5 { get; set; }
    }

    public class Connecteddatasourceinfonamemapping
    {
    }

    public class Controlpropertystate
    {
        public string InvariantPropertyName { get; set; }
        public bool AutoRuleBindingEnabled { get; set; }
        public string AutoRuleBindingString { get; set; }
        public string NameMapSourceSchema { get; set; }
        public bool IsLockable { get; set; }
        public string AFDDataSourceName { get; set; }
        public string NameMap { get; set; }
    }
}