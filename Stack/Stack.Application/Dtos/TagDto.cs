using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack.Application.Dtos;

public record TagDto(int count, bool hasSynonyms, bool isModeratorOnly, bool isRequired, string name, int? userId);

