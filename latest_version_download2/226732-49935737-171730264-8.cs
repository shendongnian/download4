    for (int i = 0; i < NumParticlesAlive; i++)
    {
        Particles[i] = new ParticleSystem.Particle();
        Particles[i].startColor 
     = (ColoursList[PlayerPrefs.GetInt("SelectedChar")].Colours[Random.Range(0, ColoursList[PlayerPrefs.GetInt("SelectedChar")].Colours.Length)]);
    }
