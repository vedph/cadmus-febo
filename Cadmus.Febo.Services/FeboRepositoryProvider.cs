﻿using System.Reflection;
using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.Core.Storage;
using Cadmus.Mongo;
using Cadmus.General.Parts;
using Cadmus.Philology.Parts;
using System;
using Cadmus.Epigraphy.Parts;
using Cadmus.Geo.Parts;

namespace Cadmus.Febo.Services;

/// <summary>
/// Cadmus Febo repository provider.
/// </summary>
/// <seealso cref="IRepositoryProvider" />
public sealed class FeboRepositoryProvider : IRepositoryProvider
{
    private readonly IPartTypeProvider _partTypeProvider;

    /// <summary>
    /// The connection string.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeboRepositoryProvider"/>
    /// class.
    /// </summary>
    public FeboRepositoryProvider()
    {
        ConnectionString = "";
        TagAttributeToTypeMap map = new();
        map.Add(
        [
            // Cadmus.General.Parts
            typeof(NotePart).GetTypeInfo().Assembly,
            // Cadmus.Philology.Parts
            typeof(ApparatusLayerFragment).GetTypeInfo().Assembly,
            // Cadmus.Epigraphy.Parts
            typeof(EpiScriptsPart).GetTypeInfo().Assembly,
            // Cadmus.Geo.Parts
            typeof(AssertedLocationsPart).GetTypeInfo().Assembly
        ]);

        _partTypeProvider = new StandardPartTypeProvider(map);
    }

    /// <summary>
    /// Gets the part type provider.
    /// </summary>
    /// <returns>part type provider</returns>
    public IPartTypeProvider GetPartTypeProvider()
    {
        return _partTypeProvider;
    }

    /// <summary>
    /// Creates a Cadmus repository.
    /// </summary>
    /// <returns>repository</returns>
    public ICadmusRepository CreateRepository()
    {
        // create the repository (no need to use container here)
        MongoCadmusRepository repository = new(_partTypeProvider,
                new StandardItemSortKeyBuilder());

        repository.Configure(new MongoCadmusRepositoryOptions
        {
            ConnectionString = ConnectionString ??
            throw new InvalidOperationException(
                "No connection string set for IRepositoryProvider implementation")
        });

        return repository;
    }
}