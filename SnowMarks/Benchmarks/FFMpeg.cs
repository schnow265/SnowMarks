using System.Reflection;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

using FFMpegCore;
using FFMpegCore.Arguments;
using FFMpegCore.Enums;

namespace SnowMarks.Benchmarks;

[ThreadingDiagnoser]
[RPlotExporter]
[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 0)]
public class FFMpeg
{
    private readonly string location = "/home/schnow265/RiderProjects/SnowMarks/SnowMarks/Resources/bbb_sunflower_2160p_60fps_normal.mp4";
    
    public FFMpeg()
    {
        //location = Path.Join(Assembly.GetCallingAssembly().Location, "bbb_sunflower_2160p_60fps_normal.mp4");
    }
    
    [Benchmark]
    public void FfmpegMultiCore() => FFMpegArguments
        .FromFileInput(location)
        .OutputToFile(Path.Join(Environment.CurrentDirectory, "multicore.mp4"), false, options => options
            .WithVideoCodec(VideoCodec.LibX264)
            .WithConstantRateFactor(21)
            .WithAudioCodec(AudioCodec.Aac)
            .WithVariableBitrate(4)
            .WithVideoFilters(filterOptions => filterOptions
                .Scale(VideoSize.Hd))
            .WithFastStart())
        .ProcessSynchronously();
    
    [Benchmark]
    public void FfmpegSingleCore() => FFMpegArguments
        .FromFileInput(location)
        .OutputToFile(Path.Join(Environment.CurrentDirectory, "singlecore.mp4"), false, options => options
            .WithArgument(new ThreadsArgument(1))
            .WithVideoCodec(VideoCodec.LibX264)
            .WithConstantRateFactor(21)
            .WithAudioCodec(AudioCodec.Aac)
            .WithVariableBitrate(4)
            .WithVideoFilters(filterOptions => filterOptions
                .Scale(VideoSize.Hd))
            .WithFastStart())
        .ProcessSynchronously();
}