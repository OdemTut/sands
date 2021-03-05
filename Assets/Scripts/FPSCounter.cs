using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;
using System.Text;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text text;
    public int count = 0;
    float time = 0;
    ProfilerRecorder systemMemoryRec;
    ProfilerRecorder GPUThreadRec;
    ProfilerRecorder MainThreadRec;
    static double GetRecorderFrameAverage(ProfilerRecorder recorder)
    {
        var samplesCount = recorder.Capacity;
        if (samplesCount == 0)
            return 0;

        double r = 0;
        unsafe
        {
            var samples = stackalloc ProfilerRecorderSample[samplesCount];
            recorder.CopyTo(samples, samplesCount);
            for (var i = 0; i < samplesCount; ++i)
                r += samples[i].Value;
            r /= samplesCount;
        }

        return r;
    }
    private void OnEnable()
    {
        systemMemoryRec = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        MainThreadRec = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15);
        GPUThreadRec = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "GPU ms");
    }
    private void OnDisable()
    {
        systemMemoryRec.Dispose();
        MainThreadRec.Dispose();
        GPUThreadRec.Dispose();
    }
    void Update()
    {
        count++;
        if (time >= 1)
        {
            time = 0;
            text.text = "Fps:" + count;
            text.text += "\n" + $"System Memory: {systemMemoryRec.LastValue / (1024 * 1024)} MB";
            text.text += "\n" + $"Frame Time: {GetRecorderFrameAverage(MainThreadRec) * (1e-6f):F1} ms";
            //text.text += "\n" + $"GPU Time: {GPUThreadRec.LastValue * (1e-6f):F1} ms";
            count = 0;
        }
        else
        {
            time += Time.unscaledDeltaTime;
            
        }
    }
}
