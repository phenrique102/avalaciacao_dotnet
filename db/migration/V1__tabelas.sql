-- --------------------------------------------------------

--
-- Estrutura para tabela `Aluno`
--

CREATE TABLE `Aluno` (
  `idAluno` int NOT NULL,
  `noAluno` varchar(80) NOT NULL,
  `dtNascimento` date NOT NULL,
  `dsSexo` char(1) NOT NULL,
  `flAtivo` char(1) NOT NULL,
  `dsComentario` varchar(4000) DEFAULT NULL,
  `idPlano` int NOT NULL
) ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `Plano`
--

CREATE TABLE `Plano` (
  `idPlano` int NOT NULL,
  `noPlano` varchar(200) NOT NULL,
  `dsPlano` varchar(4000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Despejando dados para a tabela `Plano`
--


-- --------------------------------------------------------

--
-- Estrutura para tabela `Usuario`
--

CREATE TABLE `Usuario` (
  `idUsuario` int NOT NULL,
  `dsNome` varchar(80) NOT NULL,
  `dsEmail` varchar(120) NOT NULL,
  `dsSenha` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `Aluno`
--
ALTER TABLE `Aluno`
  ADD PRIMARY KEY (`idAluno`),
  ADD KEY `fk_aluno_plano` (`idPlano`);

--
-- Índices de tabela `Plano`
--
ALTER TABLE `Plano`
  ADD PRIMARY KEY (`idPlano`);

--
-- Índices de tabela `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`idUsuario`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `Aluno`
--
ALTER TABLE `Aluno`
  MODIFY `idAluno` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `Plano`
--
ALTER TABLE `Plano`
  MODIFY `idPlano` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `Usuario`
--
ALTER TABLE `Usuario`
  MODIFY `idUsuario` int NOT NULL AUTO_INCREMENT;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `Aluno`
--
ALTER TABLE `Aluno`
  ADD CONSTRAINT `fk_aluno_plano` FOREIGN KEY (`idPlano`) REFERENCES `Plano` (`idPlano`);
COMMIT;