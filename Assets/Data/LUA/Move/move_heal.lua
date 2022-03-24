function execute(score)
	for i, v in ipairs(targets) do
		v.Heal(power * score)
	end
end