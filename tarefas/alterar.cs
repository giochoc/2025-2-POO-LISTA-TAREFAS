public void Alterar(Tarefa tarefa)
{
    using (var conexao = new MySqlConnection(connectionString))
    {
        conexao.Open();
        string sql = @"UPDATE tarefa 
                       SET nome = @nome, 
                           descricao = @descricao, 
                           dataCriacao = @dataCriacao, 
                           status = @status, 
                           dataExecucao = @dataExecucao
                       WHERE id = @id";

        using (var cmd = new MySqlCommand(sql, conexao))
        {
            cmd.Parameters.AddWithValue("@id", tarefa.Id);
            cmd.Parameters.AddWithValue("@nome", tarefa.Nome);
            cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
            cmd.Parameters.AddWithValue("@dataCriacao", tarefa.DataCriacao);
            cmd.Parameters.AddWithValue("@status", tarefa.Status);
            cmd.Parameters.AddWithValue("@dataExecucao", tarefa.DataExecucao);

            int linhasAfetadas = cmd.ExecuteNonQuery();

            if (linhasAfetadas > 0)
                Console.WriteLine("✅ Tarefa alterada com sucesso!");
            else
                Console.WriteLine("⚠️ Nenhuma tarefa encontrada com o ID informado.");
        }
    }
}

public void Excluir(int id)
{
    using (var conexao = new MySqlConnection(connectionString))
    {
        conexao.Open();
        string sql = "DELETE FROM tarefa WHERE id = @id";

        using (var cmd = new MySqlCommand(sql, conexao))
        {
            cmd.Parameters.AddWithValue("@id", id);

            int linhasAfetadas = cmd.ExecuteNonQuery();

            if (linhasAfetadas > 0)
                Console.WriteLine("✅ Tarefa excluída com sucesso!");
            else
                Console.WriteLine("⚠️ Nenhuma tarefa encontrada com o ID informado.");
        }
    }
}
