namespace Teste_Desenvolvimento_Infra.Sql
{
    public static class Consultas
    {
        #region INSERT
        public const string InserirImovel = @"INSERT INTO imovel (preco, imobiliaria_id, proprietario_id, endereco_id) 
                                              VALUES(@preco, @imobiliaria_id, @proprietario_id, @endereco_id);";

        public const string InserirImobiliaria = @"INSERT INTO imobiliaria (nome, razaoSocial, telefone)
                                                VALUES(@nome, @razaoSocial, @telefone);";

        public const string InserirProprietario = @"INSERT INTO proprietario (nome, telefone, cpf) 
                                                  VALUES(@nome, @telefone, @cpf);";

        public const string InserirEndereco = @"INSERT INTO endereco (cep, logradouro, numero, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi)
                                              VALUES(@cep, @logradouro, @numero, @complemento, @bairro, @localidade, @uf, @ibge, @gia, @ddd, @siafi);";
        #endregion


        //SELECT QUERIES -------
        public const string ConsultarImovel = @"SELECT id, preco, proprietario_id as proprietarioid, imobiliaria_id as imobiliariaid, endereco_id as enderecoid 
                                              FROM imovel WHERE id = @id;";

        public const string ConsultarImobiliaria = @"SELECT id, razaoSocial, nome, telefone 
                                                   FROM imobiliaria WHERE id = @id;";

        public const string ConsultarProprietario = @"SELECT id, nome, telefone, cpf 
                                                    FROM proprietario WHERE id = @id;";

        public const string ConsultarEndereco = @"SELECT id, cep, numero, complemento, logradouro, bairro, localidade, uf, ibge, gia, ddd, siafi
                                                FROM endereco WHERE id = @id;";


        //UPDATE QUERIES -------
        public const string AtualizarImovel = @"UPDATE imovel SET preco = @preco, imobiliaria_id = @imobiliaria_id, proprietario_id = @proprietario_id, endereco_id = @endereco_id
                                              WHERE id = @id;";

        public const string AtualizarImobiliaria = @"UPDATE imobiliaria SET nome = @nome, razaoSocial = @razaoSocial,  telefone = @telefone
                                              WHERE id = @id;";

        public const string AtualizarProprietario = @"UPDATE proprietario SET nome = @nome, telefone = @telefone, cpf = @cpf
                                                     WHERE id = @id;";

        public const string AtualizarEndereco = @"UPDATE endereco SET cep = @cep, numero = @numero, complemento = @complemento, logradouro = @logradouro, bairro = @bairro, localidade = @localidade, uf = @uf, ibge = @ibge, gia = @gia, ddd = @ddd, siafi = @siafi
                                                WHERE id = @id;";


        //DELETE QUERIES -------
        public const string ExcluirImovel = @"DELETE FROM 
                                            imovel WHERE id = @id;";

        public const string ExcluirImobiliaria = @"DELETE FROM 
                                                imobiliaria WHERE id = @id;";

        public const string ExcluirProprietario = @"DELETE FROM 
                                                  proprietario WHERE id = @id;";

        public const string ExcluirEndereco = @"DELETE FROM 
                                              endereco WHERE id = @id;";

    }
}
