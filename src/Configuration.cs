/**
 * Copyright (c) 2019 Emilian Roman
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System.IO;

namespace SPV3
{
  public partial class Configuration
  {
    public ConfigurationLoader  Loader  { get; set; } = new ConfigurationLoader();
    public ConfigurationKernel  Kernel  { get; set; } = new ConfigurationKernel();
    public ConfigurationShaders Shaders { get; set; } = new ConfigurationShaders();

    public void Load()
    {
      if (File.Exists(Paths.Configuration))
        Loader.Load();

      if (File.Exists(HXE.Paths.Configuration))
      {
        var configuration = (HXE.Configuration) HXE.Paths.Configuration;
        configuration.Load();

        /* core */
        {
          Kernel.SkipVerifyMainAssets = configuration.Kernel.SkipVerifyMainAssets;
          Kernel.SkipInvokeCoreTweaks = configuration.Kernel.SkipInvokeCoreTweaks;
          Kernel.SkipResumeCheckpoint = configuration.Kernel.SkipResumeCheckpoint;
          Kernel.SkipSetShadersConfig = configuration.Kernel.SkipSetShadersConfig;
          Kernel.SkipInvokeExecutable = configuration.Kernel.SkipInvokeExecutable;
          Kernel.SkipPatchLargeAAware = configuration.Kernel.SkipPatchLargeAAware;
          Kernel.EnableSpv3KernelMode = configuration.Kernel.EnableSpv3KernelMode;
          Kernel.EnableSpv3LegacyMode = configuration.Kernel.EnableSpv3LegacyMode;
        }

        /* shaders */
        {
          Shaders.DynamicLensFlares = configuration.PostProcessing.DynamicLensFlares;
          Shaders.Volumetrics       = configuration.PostProcessing.Volumetrics;
          Shaders.LensDirt          = configuration.PostProcessing.LensDirt;
          Shaders.HudVisor          = configuration.PostProcessing.HudVisor;
          Shaders.FilmGrain         = configuration.PostProcessing.FilmGrain;
        }
      }
    }

    public void Save()
    {
      Loader.Save();

      var configuration = (HXE.Configuration) HXE.Paths.Configuration;

      /* core */
      {
        configuration.Kernel.SkipVerifyMainAssets = Kernel.SkipVerifyMainAssets;
        configuration.Kernel.SkipInvokeCoreTweaks = Kernel.SkipInvokeCoreTweaks;
        configuration.Kernel.SkipResumeCheckpoint = Kernel.SkipResumeCheckpoint;
        configuration.Kernel.SkipSetShadersConfig = Kernel.SkipSetShadersConfig;
        configuration.Kernel.SkipInvokeExecutable = Kernel.SkipInvokeExecutable;
        configuration.Kernel.SkipPatchLargeAAware = Kernel.SkipPatchLargeAAware;
        configuration.Kernel.EnableSpv3KernelMode = Kernel.EnableSpv3KernelMode;
        configuration.Kernel.EnableSpv3LegacyMode = Kernel.EnableSpv3LegacyMode;
      }

      /* shaders */
      {
        configuration.PostProcessing.DynamicLensFlares = Shaders.DynamicLensFlares;
        configuration.PostProcessing.Volumetrics       = Shaders.Volumetrics;
        configuration.PostProcessing.LensDirt          = Shaders.LensDirt;
        configuration.PostProcessing.HudVisor          = Shaders.HudVisor;
        configuration.PostProcessing.FilmGrain         = Shaders.FilmGrain;
      }

      configuration.Save();
    }
  }
}