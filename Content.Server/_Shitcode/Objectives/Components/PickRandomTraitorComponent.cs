// SPDX-FileCopyrightText: 2024 Mary <mary@thughunt.ing>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Misandry <mary@thughunt.ing>
// SPDX-FileCopyrightText: 2025 gus <august.eymann@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Server.Objectives.Components;
using Content.Server._DV.Objectives.Systems;

namespace Content.Server._Goobstation.Objectives.Components;

/// <summary>
/// Sets the target for <see cref="TargetObjectiveComponent"/> to a random traitor
/// If there are no traitors it will fallback to any person.
/// </summary>
[RegisterComponent]
public sealed partial class PickRandomTraitorComponent : Component
{
    /// Credit to DV for side objectives/code
    /// <summary>
    /// Minimum reputation to require, or 0 for no requirement.
    /// </summary>
    [DataField]
    public int MinReputation;

    /// <summary>
    /// Minimum number of active contracts a traitor needs to have.
    /// By necessity requires a traitor to have a PDA that isn't deleted.
    /// </summary>
    [DataField]
    public int MinContracts;
}
