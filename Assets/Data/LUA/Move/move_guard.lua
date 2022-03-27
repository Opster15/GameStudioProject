function execute(score)
    for i, v in ipairs(targets) do
        Debug(Stats.Defence)
        v.AddStatModifier(Stats.Defence, 5 * (power / 100) * score, 1)
    end
end