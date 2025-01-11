# SnowMarks

Benchmarks to find out how shit your Device is.

## Requirements

- [.NET](https://dot.net) (*obviously*)
- [FFMpeg](https://ffmpeg.org)
- [R](https://r-project.org) (for the result Plots)
  - You will also need to manually install the ``ggplot2`` library. To do this enter the ``R`` command in your shell to get to the R-CLI, and enter the command:
    ```shell
    install.packages("textshaping", repos = "https://cran.rstudio.com/")
    install.packages("ragg", repos = "https://cran.rstudio.com/")
    install.packages("ggplot2", repos = "https://cran.rstudio.com/")
    ```
- [The BigBuckBunny Video placed into the Resources folder unzipped and named as-is](https://download.blender.org/demo/movies/BBB/bbb_sunflower_2160p_60fps_normal.mp4.zip)
- IF you want to run the FFMpeg Benchmarks, you will need to edit the code right now to change the location of the source footage. The required Edit is in the [SnowMarks/Benchmarks/FFMpeg.cs](SnowMarks/Benchmarks/FFMpeg.cs) on line 17.

## Running the Benchmarks

Open a terminal and run the following commands in a directory:

```shell
git clone https://github.com/schnow265/SnowMarks.git
cd SnowMarks/SnowMarks
# Run all benchmarks.
# Omit the "-- --filter *" to chose interactively which benchmarks you want to run
dotnet run -c Release -- --filter *
```