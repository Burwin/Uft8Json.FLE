﻿using JsonCryption.Encrypters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonCryption
{
    internal abstract class EncryptedConverter<T> : JsonConverter<T>
    {
        protected readonly Encrypter _encrypter;
        protected readonly JsonSerializerOptions _options;

        protected EncryptedConverter(Encrypter encrypter, JsonSerializerOptions options)
        {
            _encrypter = encrypter;
            _options = options;
        }
    }
}
