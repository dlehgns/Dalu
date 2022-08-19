using UnityEngine;
using UnityEngine.UI;
using agora_gaming_rtc;
using System.Collections.Generic;
using Photon.Pun;
using System.Collections;

public class AgoraVideoStart : MonoBehaviour
{
    [SerializeField] private GameObject userVideoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spaceBetweenUserVideos = 150f;
    [SerializeField] private string AppID = "your_appid";
    [SerializeField] private string ChannelName = "0";
    public PhotonView photonView;

    private List<GameObject> playerVideoList;
    private IRtcEngine mRtcEngine;
    private string token = "";
    private string originalChannel;
    private uint myUID = 0;


    public void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        playerVideoList = new List<GameObject>();

        if (mRtcEngine != null)
        {
            IRtcEngine.Destroy();
        }

        originalChannel = ChannelName;

        loadEngine(AppID);
    }

    // load agora engine
    public void loadEngine(string appId)
    {
        if (mRtcEngine != null)
        {
            Debug.Log("Engine exists. Please unload it first!");
            return;
        }

        // init engine
        mRtcEngine = IRtcEngine.GetEngine(appId);

        // Setup square video profile
        VideoEncoderConfiguration config = new VideoEncoderConfiguration();
        config.dimensions.width = 480;
        config.dimensions.height = 480;
        config.frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
        config.bitrate = 800;
        config.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
        mRtcEngine.SetVideoEncoderConfiguration(config);

        // Setup our callbacks (there are many other Agora callbacks, however these are the calls we need).
        mRtcEngine.OnJoinChannelSuccess = onJoinChannelSuccess;
        mRtcEngine.OnUserJoined = onUserJoined;
        mRtcEngine.OnUserOffline = onUserOffline;

        // Your video feed will not render if EnableVideo() isn't called. 
        mRtcEngine.EnableVideo();
        mRtcEngine.EnableVideoObserver();

        // By setting our UID to "0" the Agora Engine creates a unique UID and returns it in the OnJoinChannelSuccess callback. 
        mRtcEngine.JoinChannel(ChannelName, null, 0);
    }

    public void join(string channel)
    {
        Debug.Log("calling join (channel = " + channel + ")");

        if (mRtcEngine == null)
            return;

        // set callbacks (optional)
        mRtcEngine.OnJoinChannelSuccess = onJoinChannelSuccess;
        mRtcEngine.OnUserJoined = onUserJoined;
        mRtcEngine.OnUserOffline = onUserOffline;
        mRtcEngine.OnWarning = (int warn, string msg) =>
        {
            Debug.LogWarningFormat("Warning code:{0} msg:{1}", warn, IRtcEngine.GetErrorDescription(warn));
        };
        mRtcEngine.OnError = HandleError;

        // enable video
        mRtcEngine.EnableVideo();
        // allow camera output callback
        mRtcEngine.EnableVideoObserver();

        /*  This API Accepts AppID with token; by default omiting info and use 0 as the local user id */
        mRtcEngine.JoinChannelByKey(channelKey: token, channelName: channel);
    }

    public string getSdkVersion()
    {
        string ver = IRtcEngine.GetSdkVersion();
        return ver;
    }

    public void leave()
    {
        Debug.Log("calling leave");

        if (mRtcEngine == null)
            return;

        // leave channel
        mRtcEngine.LeaveChannel();
        // deregister video frame observers in native-c code
        mRtcEngine.DisableVideoObserver();
    }

    // unload agora engine
    public void unloadEngine()
    {
        Debug.Log("calling unloadEngine");

        // delete
        if (mRtcEngine != null)
        {
            IRtcEngine.Destroy();  // Place this call in ApplicationQuit
            mRtcEngine = null;
        }
    }

    public void EnableVideo(bool pauseVideo)
    {
        if (mRtcEngine != null)
        {
            if (!pauseVideo)
            {
                mRtcEngine.EnableVideo();
            }
            else
            {
                mRtcEngine.DisableVideo();
            }
        }
    }


    // Local Client Joins Channel.
    private void onJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        Debug.Log("JoinChannelSuccessHandler: uid = " + uid);

        myUID = uid;

        CreateUserVideoSurface(uid, true);

    }

    // Remote Client Joins Channel.
    private void onUserJoined(uint uid, int elapsed)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        CreateUserVideoSurface(uid, false);
    }

    public VideoSurface makePlaneSurface(string goName)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);

        if (go == null)
        {
            return null;
        }
        go.name = goName;
        // set up transform
        go.transform.Rotate(-90.0f, 0.0f, 0.0f);
        float yPos = Random.Range(3.0f, 5.0f);
        float xPos = Random.Range(-2.0f, 2.0f);
        go.transform.position = new Vector3(xPos, yPos, 0f);
        go.transform.localScale = new Vector3(0.25f, 0.5f, .5f);

        // configure videoSurface
        VideoSurface videoSurface = go.AddComponent<VideoSurface>();
        return videoSurface;
    }

    private const float Offset = 100;
    public VideoSurface makeImageSurface(string goName)
    {
        GameObject go = new GameObject();

        if (go == null)
        {
            return null;
        }

        go.name = goName;

        // to be renderered onto
        go.AddComponent<RawImage>();

        // make the object draggable
        
        // set up transform
        go.transform.Rotate(0f, 0.0f, 180.0f);
        float xPos = Random.Range(Offset - Screen.width / 2f, Screen.width / 2f - Offset);
        float yPos = Random.Range(Offset, Screen.height / 2f - Offset);
        go.transform.localPosition = new Vector3(xPos, yPos, 0f);
        go.transform.localScale = new Vector3(3f, 4f, 1f);

        // configure videoSurface
        VideoSurface videoSurface = go.AddComponent<VideoSurface>();
        return videoSurface;
    }
    // When remote user is offline, this delegate will be called. Typically
    // delete the GameObject for this user
    private void onUserOffline(uint uid, USER_OFFLINE_REASON reason)
    {
        // remove video stream
        Debug.Log("onUserOffline: uid = " + uid + " reason = " + reason);
        // this is called in main thread
        GameObject go = GameObject.Find(uid.ToString());
        if (!ReferenceEquals(go, null))
        {
            Object.Destroy(go);
        }
    }

    #region Error Handling
    private int LastError { get; set; }
    private void HandleError(int error, string msg)
    {
        if (error == LastError)
        {
            return;
        }

        if (string.IsNullOrEmpty(msg))
        {
            msg = string.Format("Error code:{0} msg:{1}", error, IRtcEngine.GetErrorDescription(error));
        }

        switch (error)
        {
            case 101:
                msg += "\nPlease make sure your AppId is valid and it does not require a certificate for this demo.";
                break;
        }


        LastError = error;
    }

    #endregion

    private void CreateUserVideoSurface(uint uid, bool isLocalUser)
    {
        // Avoid duplicating Local player VideoSurface image plane.
        for (int i = 0; i < playerVideoList.Count; i++)
        {
            if (playerVideoList[i].name == uid.ToString())
            {
                return;
            }
        }

        // Get the next position for newly created VideoSurface to place inside UI Container.
        //float spawnY = playerVideoList.Count * spaceBetweenUserVideos;
        //Vector3 spawnPosition = new Vector3(0, -spawnY, 0);

        Vector3 spawnPosition = new Vector3(0,0, 0);

        // Create Gameobject that will serve as our VideoSurface.
        GameObject newUserVideo = Instantiate(userVideoPrefab, spawnPosition, spawnPoint.rotation);
        if (newUserVideo == null)
        {
            Debug.LogError("CreateUserVideoSurface() - newUserVideoIsNull");
            return;
        }
        newUserVideo.name = uid.ToString();
        newUserVideo.transform.SetParent(spawnPoint, false);
        newUserVideo.transform.rotation = Quaternion.Euler(Vector3.right * -180);

        playerVideoList.Add(newUserVideo);

        // Update our VideoSurface to reflect new users
        VideoSurface newVideoSurface = newUserVideo.GetComponent<VideoSurface>();
        if (newVideoSurface == null)
        {
            Debug.LogError("CreateUserVideoSurface() - VideoSurface component is null on newly joined user");
            return;
        }

        if (isLocalUser == false)
        {
            newVideoSurface.SetForUser(uid);
        }
        //newVideoSurface.SetGameFps(30);

        // Update our "Content" container that holds all the newUserVideo image planes
        //content.sizeDelta = new Vector2(0, playerVideoList.Count * spaceBetweenUserVideos + 140);

        UpdatePlayerVideoPostions();
    }

    private void UpdatePlayerVideoPostions()
    {
        for (int i = 0; i < playerVideoList.Count; i++)
        {
            //playerVideoList[i].GetComponent<RectTransform>().anchoredPosition = Vector2.right * spaceBetweenUserVideos * i;

            playerVideoList[i].transform.SetAsLastSibling();
        }
    }

    private void TerminateAgoraEngine()
    {
        if (mRtcEngine != null)
        {
            mRtcEngine.LeaveChannel();
            mRtcEngine = null;
            IRtcEngine.Destroy();
        }
    }


    private void OnApplicationQuit()
    {
        TerminateAgoraEngine();
    }
}
