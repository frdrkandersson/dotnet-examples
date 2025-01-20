using System.Text.Json.Serialization;

namespace PolymorphicApi.Models;


//[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Rectangle), typeDiscriminator: nameof(Rectangle))]
[JsonDerivedType(typeof(Circle), typeDiscriminator: nameof(Circle))]
public abstract record Shape();