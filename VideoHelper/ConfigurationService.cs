using Newtonsoft.Json;

namespace VideoHelper;

public class ConfigurationService{

    public void StoreConfig(Configuration configuration)
    {
        if(configuration.PathToStoreConfig == null){
            return;
        }
        
        var jsonConfig = JsonConvert.SerializeObject(configuration.VideoConfig);

        File.WriteAllText(configuration.PathToStoreConfig, jsonConfig);
    }

    public VideoConfig? RestoreConfig(string path){

        var jsonConfig = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<VideoConfig>(jsonConfig);
    } 
}