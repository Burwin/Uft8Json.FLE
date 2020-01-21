﻿using JsonCryption.Encrypters;
using System;
using System.Text.Json;

namespace JsonCryption.Converters
{
    internal sealed class DecimalConverter : EncryptedConverter<decimal>
    {
        public DecimalConverter(Encrypter encrypter, JsonSerializerOptions options) : base(encrypter, options)
        {
        }

        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) => throw new NotImplementedException();
    }
}
