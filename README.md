# SnowMarks

Benchmarks to find out how shit your Device is.

## Requirements

- [.NET](https://dot.net) (*obviously*)
- [FFMpeg](https://ffmpeg.org)
- [R](https://r-project.org) (for the result Plots)
- [The BigBuckBunny Video placed into the Resources folder unzipped and named as-is](https://download.blender.org/demo/movies/BBB/bbb_sunflower_2160p_60fps_normal.mp4.zip)

## Running the Benchmarks

Open a terminal and run the following commands in a directory:

```shell
git clone https://github.com/schnow265/SnowMarks.git
cd SnowMarks/SnowMarks
# Run all benchmarks.
# Omit the "-- --filter *" to chose interactively which benchmarks you want to run
dotnet run -c Release -- --filter *
```