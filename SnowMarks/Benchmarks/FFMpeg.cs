using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

using FFMpegCore;
using FFMpegCore.Arguments;
using FFMpegCore.Enums;

namespace SnowMarks.Benchmarks;

[ThreadingDiagnoser]
[RPlotExporter]
[SimpleJob(RunStrategy.ColdStart, iterationCount: 2)]
[BenchmarkCategory("FFMpeg")]
public class FFMpeg
{
    private readonly string location = "/home/schnow265/RiderProjects/SnowMarks/SnowMarks/Resources/bbb_sunflower_2160p_60fps_normal.mp4";

    [Benchmark(Description = "Multi Threaded")]
    public void FfmpegMultiCore() => FFMpegArguments
        .FromFileInput(location)
        .OutputToFile(Path.Join(Environment.CurrentDirectory, $"multicore-{DateTime.Now:h-mm-ss-tt}.mp4"), false, options => options
            .WithVideoCodec(VideoCodec.LibX264)
            .WithConstantRateFactor(21)
            .WithAudioCodec(AudioCodec.Aac)
            .WithVariableBitrate(4)
            .WithVideoFilters(filterOptions => filterOptions
                .Scale(VideoSize.Hd))
            .WithFastStart())
        .ProcessSynchronously();
    
    [Benchmark(Description = "Single Threaded")]
    public void FfmpegSingleCore() => FFMpegArguments
        .FromFileInput(location)
        .OutputToFile(Path.Join(Environment.CurrentDirectory, $"singlecore-{DateTime.Now:h-mm-ss-tt}.mp4"), false, options => options
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