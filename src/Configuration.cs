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

using System.Collections.Generic;
using static HXE.OpenSauce.OpenSauceObjects.ObjectsWeapon;

namespace SPV3
{
  public partial class Configuration
  {
    public ConfigurationLoader    Loader    { get; set; } = new ConfigurationLoader();
    public ConfigurationShaders   Shaders   { get; set; } = new ConfigurationShaders();
    public ConfigurationOpenSauce OpenSauce { get; set; } = new ConfigurationOpenSauce();
    public ConfigurationChimera   Chimera   { get; set; } = new ConfigurationChimera();

    public void Load()
    {
      Loader.Load();
      Shaders.Load();
      OpenSauce.Load();
      Chimera.Load();
    }

    public void Save()
    {
      Loader.Save();
      Shaders.Save();
      OpenSauce.Save();
      Chimera.Save();
    }

    public void CalculateFOV()
    {
      OpenSauce.FieldOfView = OpenSauce.Configuration.Camera.CalculateFOV(Loader.Width, Loader.Height);
    }

    public void ResetWeaponPositions()
    {
      OpenSauce.Configuration.Objects.Weapon.Positions = new List<PositionWeapon>();
    }
  }
}