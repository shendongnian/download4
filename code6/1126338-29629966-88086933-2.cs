    var waveStream = new MemoryStream();
    using (var synthesizer = new SpeechSynthesizer())
    {
        var synthFormat =  
            new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);
        string text = "Hello World! Speech";
        synthesizer.SetOutputToAudioStream(waveStream, synthFormat);
        synthesizer.Speak("Hello World! Speech");
    }
    using (var file = File.Create(path))
    {
        // With CopyTo, you don't need to rewind first...
        waveStream.CopyTo(file);
    }
