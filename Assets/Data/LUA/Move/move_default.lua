function execute(score)
	for i, v in ipairs(targets) do
		v.Damage(power * score)
	end
end