﻿using JsonCryption.Encrypters;
using System;
using System.Text.Json;

namespace JsonCryption.Converters
{
    internal sealed class DateTimeConverter : EncryptedConverter<DateTime>
    {
        public DateTimeConverter(Encrypter encrypter, JsonSerializerOptions options) : base(encrypter, options)
        {
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => throw new NotImplementedException();
    }
}
