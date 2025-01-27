-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 27 2025 г., 11:03
-- Версия сервера: 10.3.22-MariaDB
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `ohta_park`
--

-- --------------------------------------------------------

--
-- Структура таблицы `client`
--

CREATE TABLE `client` (
  `ID` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(14) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `client`
--

INSERT INTO `client` (`ID`, `name`, `phone`) VALUES
(1, 'Иванов Иван Иванович', '89423225768'),
(2, 'Александров Александр Александрович', '89045231232'),
(3, 'Петров Петр Петрович', '89489832312');

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `ID` int(11) NOT NULL,
  `client-ID` int(11) NOT NULL,
  `room-ID` int(11) NOT NULL,
  `order-Date` date NOT NULL DEFAULT current_timestamp(),
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`ID`, `client-ID`, `room-ID`, `order-Date`, `status`) VALUES
(1, 1, 1, '2025-01-27', 1),
(2, 2, 2, '2025-01-09', 4),
(3, 3, 3, '2025-01-24', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `ppl-amount`
--

CREATE TABLE `ppl-amount` (
  `ID` int(11) NOT NULL,
  `amount` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `ppl-amount`
--

INSERT INTO `ppl-amount` (`ID`, `amount`) VALUES
(1, 'SGL'),
(2, 'DBL'),
(3, 'TWN'),
(4, 'DBL + EXB'),
(5, 'TRPL'),
(6, 'QDPL'),
(7, '5 ADL');

-- --------------------------------------------------------

--
-- Структура таблицы `room-type`
--

CREATE TABLE `room-type` (
  `ID` int(11) NOT NULL,
  `type` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `room-type`
--

INSERT INTO `room-type` (`ID`, `type`) VALUES
(1, 'Standard'),
(2, 'Superior'),
(3, 'De luxe'),
(4, 'President');

-- --------------------------------------------------------

--
-- Структура таблицы `rooms`
--

CREATE TABLE `rooms` (
  `ID` int(11) NOT NULL,
  `room-type` int(11) NOT NULL,
  `ppl-amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `rooms`
--

INSERT INTO `rooms` (`ID`, `room-type`, `ppl-amount`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 2, 4),
(5, 3, 5),
(6, 4, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `status`
--

CREATE TABLE `status` (
  `ID` int(11) NOT NULL,
  `name` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `status`
--

INSERT INTO `status` (`ID`, `name`) VALUES
(1, 'активный'),
(2, 'заблокированный'),
(3, 'создан заранее'),
(4, 'завершенный');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `client-ID` (`client-ID`),
  ADD KEY `room-ID` (`room-ID`),
  ADD KEY `status` (`status`);

--
-- Индексы таблицы `ppl-amount`
--
ALTER TABLE `ppl-amount`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `room-type`
--
ALTER TABLE `room-type`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `room-type` (`room-type`),
  ADD KEY `ppl-amount` (`ppl-amount`);

--
-- Индексы таблицы `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `client`
--
ALTER TABLE `client`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `ppl-amount`
--
ALTER TABLE `ppl-amount`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `room-type`
--
ALTER TABLE `room-type`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `rooms`
--
ALTER TABLE `rooms`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `status`
--
ALTER TABLE `status`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`room-ID`) REFERENCES `rooms` (`ID`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`status`) REFERENCES `status` (`ID`),
  ADD CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`client-ID`) REFERENCES `client` (`ID`);

--
-- Ограничения внешнего ключа таблицы `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `rooms_ibfk_1` FOREIGN KEY (`room-type`) REFERENCES `room-type` (`ID`),
  ADD CONSTRAINT `rooms_ibfk_2` FOREIGN KEY (`ppl-amount`) REFERENCES `ppl-amount` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
