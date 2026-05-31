using Mapster;
using CondominioApi.Models;
using CondominioApi.DTOs;

namespace CondominioApi.Mapping;

public static class MapsterConfig
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        // Apartamento mappings
        config.NewConfig<Apartamento, ApartamentoResponseDto>();
        config.NewConfig<ApartamentoCreateDto, Apartamento>()
            .IgnoreNullValues(true);
        config.NewConfig<ApartamentoUpdateDto, Apartamento>()
            .IgnoreNullValues(true);

        // DadosCobranca
        config.NewConfig<DadosCobranca, DadosCobrancaDto>();
        config.NewConfig<DadosCobrancaDto, DadosCobranca>().IgnoreNullValues(true);

        // Credito
        config.NewConfig<Credito, CreditoDto>();
        config.NewConfig<CreditoDto, Credito>().IgnoreNullValues(true);
    }
}
